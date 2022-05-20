using Api.Core.Interfaces;
using Api.Core.Utils;
using Api.Infra.Data.DapperExtension;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infra.Data
{
    public class Repository<T> : IRepository<T> where T : Core.Models.BaseEntity
    {

        private readonly string _tableName = typeof(T).Name;
        private NpgsqlConnection NpgsqlConnection()
        {
            return new NpgsqlConnection(Config.AppSetting.GetSection("ConnectionStrings:Db"));
        }

        private IDbConnection CreateConnection()
        {
            var conn = NpgsqlConnection();
            conn.Open();
            return conn;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using (var connection = CreateConnection())
            {

                return await connection.QueryAsync<T>($"SELECT * FROM \"{_tableName}\"");
            }
        }
        public async Task<PaginationResult<T>> GetAllPaginated(int pageSize, int pageNumber)
        {
            int offset = GetOffset(pageSize, pageNumber);
            string sql = @$"SELECT COUNT(0) FROM public.""{_tableName}"";
            SELECT * FROM public.""{_tableName}""
            OFFSET @Offset ROWS
            FETCH NEXT @PageSize ROWS ONLY";

            using var connection = CreateConnection();
            var multi = await connection.QueryMultipleAsync(sql, new { pageSize, offset });
            int totalRowCount = multi.Read<int>().Single();
            List<T> gridDataRows = multi.Read<T>().ToList();
            return new PaginationResult<T> { TotalCount = totalRowCount, Data = gridDataRows };
        }
        private static int GetOffset(int pageSize, int pageNumber)
        {
            if (pageNumber == 0)
                pageNumber = 1;
            return (pageNumber - 1) * pageSize;
        }
        protected async Task<T> DbAction(Func<IDbConnection, Task<T>> action)
        {
            using (var connection = CreateConnection())
            {
                var result = await action(connection);
                return result;
            }
        }
        public async Task DeleteRowAsync(Guid id)
        {
            using (var connection = CreateConnection())
            {
                await connection.SaveChanges($"DELETE FROM \"{_tableName}\" WHERE \"Id\"=@Id", id);
            }
        }

        public async Task<T> GetAsync(Guid id)
        {
            using (var connection = CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<T>($"SELECT * FROM public.\"{_tableName}\" WHERE \"Id\"=@Id", new { Id = id });
                return result;
            }
        }
        public async Task UpdateAsync(T t)
        {
            var updateQuery = GenerateUpdateQuery();

            using (var connection = CreateConnection())
            {
                await connection.SaveChanges(updateQuery, t);
            }
        }

        private string GenerateUpdateQuery()
        {
            var updateQuery = new StringBuilder($"UPDATE public.\"{_tableName}\" SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"\"{property}\"=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE \"Id\"=@Id");

            return updateQuery.ToString();
        }
        public async Task<int> SaveRangeAsync(IEnumerable<T> list)
        {
            var inserted = 0;
            var query = GenerateInsertQuery();
            using (var connection = CreateConnection())
            {
                inserted += await connection.ExecuteAsync(query, list);
            }

            return inserted;
        }
        public async Task InsertAsync(T t)
        {
            var insertQuery = GenerateInsertQuery();

            using (var connection = CreateConnection())
            {
                await connection.SaveChanges(insertQuery, t);
            }
        }
        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
        private string GenerateInsertQuery()
        {
            var insertQuery = new StringBuilder($"INSERT INTO  public.\"{_tableName}\" ");

            insertQuery.Append("(");

            var properties = GenerateListOfProperties(GetProperties);
            properties.ForEach(prop => { insertQuery.Append($"\"{prop}\","); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(") VALUES (");

            properties.ForEach(prop => { insertQuery.Append($"@{prop},"); });

            insertQuery
                .Remove(insertQuery.Length - 1, 1)
                .Append(")");

            return insertQuery.ToString();
        }
        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {

            return listOfProperties.Where(o => o.GetCustomAttribute(typeof(ColumnAttribute), false) != null).Select(o=> o.Name).ToList();
        }
    }
}
