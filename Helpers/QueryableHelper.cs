using ProvaPub.Dtos;

namespace ProvaPub.Helpers;

public static class QueryableHelper
{
    public static IQueryable<T> PageBy<T>(this IQueryable<T> source, PaginatedRequestDto request)
    {
        return source.Skip(request.SkipPage!.Value)
                     .Take(request.Limit);
    }
}