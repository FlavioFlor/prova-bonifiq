using ProvaPub.Dtos;
using ProvaPub.Models;

namespace ProvaPub.Contracts;

public interface IProductService
{
    PaginatedResponseDto<Product> ListProducts(PaginatedRequestDto request);
}