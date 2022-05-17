using Dapper;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Api.Infra.Data.DapperExtension
{
    public static class DapperExtension
    {
        const string INSERT_OPERATION = "INSERT";
        const string UPDATE_OPERATION = "UPDATE";
        public static async Task<int> SaveChanges<T>(this IDbConnection ctx, string sql, T obj)
        {
            SetValuePropsAudit(sql, obj);
            using (ctx)
                return await ctx.ExecuteAsync(sql, obj);
        }
        public static async Task<int> SaveChanges(this IDbConnection ctx, string sql, Guid id)
        {
            using (ctx)
                return await ctx.ExecuteAsync(sql, new { Id = id });
        }
        private static void SetValuePropsAudit<T>(string Sql, T obj)
        {
            var entity = (obj as Core.Models.BaseEntity);
            if (entity is null)
                return;
            if (Sql.IndexOf(UPDATE_OPERATION) > -1)
                entity.DataAtualizacao = DateTime.Now;
            if (Sql.IndexOf(INSERT_OPERATION) > -1)
            {
                entity.DataCadastro = DateTime.Now;
                entity.DataAtualizacao = DateTime.Now;
            }
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();
        }
    }
}
