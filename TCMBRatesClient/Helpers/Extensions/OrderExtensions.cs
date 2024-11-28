using System.Linq.Expressions;
using TCMBRatesClient.Models.Enums;

namespace TCMBRatesClient.Helpers.Extensions;
public static class OrderExtensions
{
    public static IQueryable<T> DynamicOrder<T>(this IQueryable<T> query, string fieldName, OrderDirection? direction = OrderDirection.Ascending)
    {
        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.Property(parameter, fieldName!);
        var lambda = Expression.Lambda(property, parameter);

        string methodName = direction == OrderDirection.Ascending ? "OrderBy" : "OrderByDescending";

        var method = typeof(Queryable).GetMethods()
            .First(m => m.Name == methodName && m.GetParameters().Length == 2);

        var genericMethod = method.MakeGenericMethod(typeof(T), property.Type);

        var sortedQuery = genericMethod.Invoke(null, [query, lambda]) as IQueryable<T>;

        return sortedQuery ?? query;
    }
}
