using ProvaPub.Contracts;
using ProvaPub.Dtos;
using ProvaPub.Helpers;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services;

public sealed class ProductService : IProductService
{
	private readonly TestDbContext _ctx;

	public ProductService(TestDbContext ctx)
	{
		_ctx = ctx;
	}

	public PaginatedResponseDto<Product> ListProducts(PaginatedRequestDto  request)
	{
		var productsCount = _ctx.Products.Count(product => product.Name.ToLower().StartsWith(request.Filter.ToLower()));
			
		var products = _ctx.Products.Where(product => product.Name.ToLower().StartsWith(request.Filter.ToLower()))
			.PageBy(request)
			.ToList();

		var paginatedResponse = new PaginatedResponseDto<Product>(products, productsCount);
			
		return paginatedResponse;
	}
}