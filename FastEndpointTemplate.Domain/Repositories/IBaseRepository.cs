using System.Linq.Expressions;

namespace FastEndpointTemplate.Domain.Repositories;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> Get();
    IQueryable<T> Get(Expression<Func<T, bool>> predicate);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(T? entity, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    Task UpdateAsync(T? entity, CancellationToken cancellationToken);
    Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
    Task DeleteAsync(T? entity, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
}
