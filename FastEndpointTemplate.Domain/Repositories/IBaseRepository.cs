using System.Linq.Expressions;

namespace FastEndpointTemplate.Domain.Repositories;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> Get();
    IQueryable<T> Get(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteAsync(Guid id);
    Task DeleteRangeAsync(IEnumerable<T> entities);
}
