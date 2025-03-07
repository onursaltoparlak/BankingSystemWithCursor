using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace BankApp.Core.Persistence.Repositories;

public interface IAsyncRepository<T> where T : class
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IList<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool tracking = true, bool enableTracking = true, CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
} 