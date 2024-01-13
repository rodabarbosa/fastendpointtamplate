using System.Linq.Expressions;

namespace FastEndpointTemplate.Persistence.Extensions;

public static class QueryableExtension
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
    {
        return condition
            ? query.Where(predicate)
            : query;
    }
}
