namespace ProvaPub.Dtos;

public sealed class PaginatedResponseDto<TResponse>
{
    public IEnumerable<TResponse> PaginatedItems { get; }
    public int TotalCount { get; }
    public bool HasNext { get; set; }

    public PaginatedResponseDto(IEnumerable<TResponse> paginatedItems, int totalCount)
    {
        PaginatedItems = paginatedItems;
        TotalCount = totalCount;
        HasNext = paginatedItems.Any() && paginatedItems.Count() + 10 <= TotalCount;
    }
}