using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Contexts;
using ProvaPub.Contracts.Repositories;
using ProvaPub.Dtos;
using ProvaPub.Entities;
using ProvaPub.Helpers;

namespace ProvaPub.Repositories;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly TestDbContext _ctx;

    public CustomerRepository(TestDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<int> CountOrdersInThisMonthAsync(int customerId, DateTime baseDate)
    {
        var result = await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
        
        return result;
    }


    public async Task<Customer?> FindAsync(int customerId)
    {
        var customer = await _ctx.Customers.FindAsync(customerId);

        return customer;
    }

    public async Task<int> CountCustomerInThisMonthAsync(int customerId)
    {
        var result = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());

        return result;
    }


    public async Task<IEnumerable<Customer>> GetCustomerPaginatedAsync(PaginatedRequestDto request)
    {
        var customer = await _ctx.Customers.Where(customer => customer.Name.ToLower().StartsWith(request.Filter.ToLower()))
                                           .PageBy(request)
                                           .ToListAsync();

        return customer;
    }

    public async Task<int> GetCustomerPaginatedCountAsync(PaginatedRequestDto request)
    {
        var customer = await _ctx.Customers.CountAsync(customer => customer.Name.ToLower().StartsWith(request.Filter.ToLower()));

        return customer;
    }

}