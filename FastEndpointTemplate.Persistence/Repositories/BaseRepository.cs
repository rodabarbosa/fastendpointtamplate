using System.Linq.Expressions;
using FastEndpointTemplate.Persistence.Contexts;

namespace FastEndpointTemplate.Persistence.Repositories;

public abstract class BaseRepository<T> where T : class
{
    protected readonly ApplicationContext Context;

    protected BaseRepository(ApplicationContext context)
    {
        Context = context;
    }

    public IQueryable<T> Get()
    {
        return Get(null);
    }

    public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
    {
        if (predicate is null)
            return Context.Set<T>();

        return Context.Set<T>().Where(predicate);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public Task AddAsync(T entity)
    {
        Context.Set<T>().Add(entity);
        return Context.SaveChangesAsync();
    }

    public Task AddRangeAsync(IEnumerable<T> entities)
    {
        Context.Set<T>().AddRange(entities);
        return Context.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
        Context.Set<T>().Update(entity);
        return Context.SaveChangesAsync();
    }

    public Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        Context.Set<T>().UpdateRange(entities);
        return Context.SaveChangesAsync();
    }

    public Task DeleteAsync(T entity)
    {
        if (entity is null)
            return Task.CompletedTask;

        Context.Set<T>().Remove(entity);
        return Context.SaveChangesAsync();
    }

    public Task DeleteAsync(Guid id)
    {
        var entity = Context.Set<T>().Find(id);
        return DeleteAsync(entity);
    }

    public Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        if (entities is null || !entities.Any())
            return Task.CompletedTask;

        Context.Set<T>().RemoveRange(entities);
        return Context.SaveChangesAsync();
    }
}