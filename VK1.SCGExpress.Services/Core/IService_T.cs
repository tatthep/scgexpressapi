using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VK1.SCGExpress.Services.Core {
    public interface IService<T> where T : class {

        Task<IQueryable<T>> QueryAsync(Expression<Func<T, bool>> criteria);
        Task<IQueryable<T>> AllAsync();
        Task<T> FindAsync(params object[] keys);
        Task<T> AddAsync(T item);

        Task<T> UpdateAsync(T item);
        Task<T> RemoveAsync(T item);

        //AsNoTracking
        Task<IQueryable<T>> QueryAsyncAsNoTracking(Expression<Func<T, bool>> criteria);
        Task<IQueryable<T>> AllAsyncAsNoTracking();
        Task<T> SingleOrDefaultAsNoTracking(Expression<Func<T, bool>> criteria);

        //bulk
        Task BulkInsert(List<T> items);
        Task BulkDeleteAsync(List<T> items);
        Task BulkUpdateAsync(List<T> items);

    }
}
