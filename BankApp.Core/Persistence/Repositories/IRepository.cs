using System.Linq.Expressions;

namespace BankApp.Core.Persistence.Repositories;

public interface IRepository<T> where T : class
{
    T? Get(Expression<Func<T, bool>> predicate);
    IList<T> GetList(Expression<Func<T, bool>>? predicate = null);
    T Add(T entity);
    T Update(T entity);
    T Delete(T entity);
} 