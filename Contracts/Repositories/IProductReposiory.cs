using ProvaPub.Dtos;
using ProvaPub.Entities;

namespace ProvaPub.Contracts.Repositories;

public interface IProductReposiory
{
    Task<IEnumerable<Product>> GetProductsPaginatedAsync(PaginatedRequestDto request);
    Task<int> GetProductsPaginatedCountAsync(PaginatedRequestDto request);
}