using FastEndpointTemplate.Persistence.Contexts;
using FastEndpointTemplate.Shared.Exceptions;
using System.Linq.Expressions;

namespace FastEndpointTemplate.Persistence.Repositories;

public abstract class BaseRepository<T> where T : class
{
    protected readonly ApplicationContext Context;

    protected BaseRepository(ApplicationContext context)
    {
        Context = context;
    }

    public virtual IQueryable<T> Get()
    {
        return Get(null);
    }

    public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
    {
        return predicate is null ? Context.Set<T>() : Context.Set<T>().Where(predicate);
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public virtual Task AddAsync(T? entity)
    {
        AddPersistenceException.ThrowIf(entity is null, "Entity cannot be null");

        Context.Set<T>().Add(entity);

        return Context.SaveChangesAsync();
    }

    public virtual Task AddRangeAsync(IEnumerable<T> entities)
    {
        AddPersistenceException.ThrowIf(entities is null || !entities.Any(), "Entities cannot be null");

        Context.Set<T>().AddRange(entities);

        return Context.SaveChangesAsync();
    }

    public virtual Task UpdateAsync(T? entity)
    {
        UpdatePersistenceException.ThrowIf(entity is null, "Entity cannot be null");

        Context.Set<T>().Update(entity);

        return Context.SaveChangesAsync();
    }

    public virtual Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        UpdatePersistenceException.ThrowIf(entities is null || !entities.Any(), "Entities cannot be null");

        Context.Set<T>().UpdateRange(entities);

        return Context.SaveChangesAsync();
    }

    public virtual Task DeleteAsync(T entity)
    {
        DeletePersistenceException.ThrowIf(entity is null, "Entity cannot be null");

        Context.Set<T>().Remove(entity);

        return Context.SaveChangesAsync();
    }

    public virtual Task DeleteAsync(Guid id)
    {
        var entity = Context.Set<T>().Find(id);

        return DeleteAsync(entity);
    }

    public virtual Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        DeletePersistenceException.ThrowIf(entities is null || !entities.Any(), "Entities cannot be null");

        Context.Set<T>().RemoveRange(entities);

        return Context.SaveChangesAsync();
    }
}
