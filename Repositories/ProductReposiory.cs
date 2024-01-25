using Microsoft.EntityFrameworkCore;
using ProvaPub.Contexts;
using ProvaPub.Contracts.Repositories;
using ProvaPub.Dtos;
using ProvaPub.Entities;
using ProvaPub.Helpers;

namespace ProvaPub.Repositories;

public sealed class ProductReposiory : IProductReposiory
{
    private readonly TestDbContext _ctx;

    public ProductReposiory(TestDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<IEnumerable<Product>> GetProductsPaginatedAsync(PaginatedRequestDto request)
    {
        var products = await _ctx.Products.Where(product => product.Name.ToLower().StartsWith(request.Filter.ToLower()))
                                               .PageBy(request)
			                                   .ToListAsync();
        return products;
    }

    public async Task<int> GetProductsPaginatedCountAsync(PaginatedRequestDto request)
    {
        var productsCount = await _ctx.Products.CountAsync(product => product.Name.ToLower().StartsWith(request.Filter.ToLower()));
        return productsCount;
    }
}
