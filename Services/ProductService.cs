using ProvaPub.Contracts.Repositories;
using ProvaPub.Contracts.Services;
using ProvaPub.Dtos;
using ProvaPub.Entities;

namespace ProvaPub.Services;

public sealed class ProductService : IProductService
{
	private readonly IProductReposiory _productReposiory;

	public ProductService(IProductReposiory productReposiory)
	{
        _productReposiory = productReposiory;
	}

	public async Task<PaginatedResponseDto<Product>> ListProductsAsync(PaginatedRequestDto  request)
	{
		var productsCount = await _productReposiory.GetProductsPaginatedCountAsync(request);

		var products = await _productReposiory.GetProductsPaginatedAsync(request);

		var paginatedResponse = new PaginatedResponseDto<Product>(products, productsCount);
			
		return paginatedResponse;
	}
}