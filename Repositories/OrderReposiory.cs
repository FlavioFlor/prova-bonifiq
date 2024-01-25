using ProvaPub.Contexts;
using ProvaPub.Contracts.Repositories;
using ProvaPub.Entities;

namespace ProvaPub.Repositories;

public sealed class OrderReposiory : IOrderReposiory
{
    private readonly TestDbContext _ctx;

    public OrderReposiory(TestDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task AddOrder(Order order)
    {
        await _ctx.Orders.AddAsync(order);
        await _ctx.SaveChangesAsync();
    }
}
