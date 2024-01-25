using ProvaPub.Dtos;
using ProvaPub.Entities;

namespace ProvaPub.Contracts.Services;

public interface IProductService
{
    Task<PaginatedResponseDto<Product>> ListProductsAsync(PaginatedRequestDto request);
}