using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Persistence.Contexts;
using FastEndpointTemplate.Persistence.Extensions;
using FastEndpointTemplate.Shared.Exceptions;
using System.Linq.Expressions;

namespace FastEndpointTemplate.Persistence.Repositories;

public abstract class BaseRepository<T>(ApplicationContext context)
    : IBaseRepository<T> where T : class
{
    protected readonly ApplicationContext Context = context;

    public virtual IQueryable<T> Get()
    {
        return Get(null);
    }

    public virtual IQueryable<T> Get(Expression<Func<T, bool>>? predicate)
    {
        return Context.Set<T>()
            .WhereIf(predicate is not null, predicate!);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Context.Set<T>()
            .FindAsync(new object?[] { id, cancellationToken }, cancellationToken);
    }

    public virtual Task AddAsync(T? entity, CancellationToken cancellationToken)
    {
        AddPersistenceException.ThrowIf(entity is null, "Entity cannot be null");

        Context.Set<T>()
            .Add(entity!);

        return Context.SaveChangesAsync(cancellationToken);
    }

    public virtual Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        AddPersistenceException.ThrowIf(!entities.Any(), "Entities cannot be null");

        Context.Set<T>()
            .AddRange(entities);

        return Context.SaveChangesAsync(cancellationToken);
    }

    public virtual Task UpdateAsync(T? entity, CancellationToken cancellationToken)
    {
        UpdatePersistenceException.ThrowIf(entity is null, "Entity cannot be null");

        Context.Set<T>()
            .Update(entity!);

        return Context.SaveChangesAsync(cancellationToken);
    }

    public virtual Task UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        UpdatePersistenceException.ThrowIf(!entities.Any(), "Entities cannot be null");

        Context.Set<T>()
            .UpdateRange(entities);

        return Context.SaveChangesAsync(cancellationToken);
    }

    public virtual Task DeleteAsync(T? entity, CancellationToken cancellationToken)
    {
        DeletePersistenceException.ThrowIf(entity is null, "Entity cannot be null");

        Context.Set<T>()
            .Remove(entity!);

        return Context.SaveChangesAsync(cancellationToken);
    }

    public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await Context.Set<T>()
            .FindAsync(new object?[] { id, cancellationToken }, cancellationToken);

        await DeleteAsync(entity, cancellationToken);
    }

    public virtual Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        DeletePersistenceException.ThrowIf(!entities.Any(), "Entities cannot be null");

        Context.Set<T>()
            .RemoveRange(entities);

        return Context.SaveChangesAsync(cancellationToken);
    }
}
