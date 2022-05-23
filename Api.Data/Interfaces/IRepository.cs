using Api.Core.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Interfaces
{
    public interface IRepository<T> where T : Core.Models.BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<PaginationResult<T>> GetAllPaginated(int pageSize, int pageNumber);
        Task DeleteRowAsync(Guid id);
        Task<T> GetAsync(Guid id);
        Task<int> SaveRangeAsync(IEnumerable<T> list);
        Task UpdateAsync(T t);
        Task InsertAsync(T t);
        Task<T> DbAction(Func<IDbConnection, Task<T>> action);
    }
}
