using Microsoft.EntityFrameworkCore;
using ProvaPub.Contracts;
using ProvaPub.Dtos;
using ProvaPub.Helpers;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services;

public sealed class CustomerService : ICustomerService
{
    private readonly TestDbContext _ctx;

    public CustomerService(TestDbContext ctx)
    {
        _ctx = ctx;
    }
        
    public PaginatedResponseDto<Customer> ListCustomers(PaginatedRequestDto  request)
    {
        var productsCount = _ctx.Customers.Count(customer => customer.Name.ToLower().StartsWith(request.Filter.ToLower()));
			
        var customers = _ctx.Customers.Where(customer => customer.Name.ToLower().StartsWith(request.Filter.ToLower()))
                                                  .PageBy(request)
                                                  .ToList();

        var paginatedResponse = new PaginatedResponseDto<Customer>(customers, productsCount);
			
        return paginatedResponse;
    }

    public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
    {
        if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

        if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

        //Business Rule: Non registered Customers cannot purchase
        var customer = await _ctx.Customers.FindAsync(customerId);
        if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

        //Business Rule: A customer can purchase only a single time per month
        var baseDate = DateTime.UtcNow.AddMonths(-1);
        var ordersInThisMonth = await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
        if (ordersInThisMonth > 0)
            return false;

        //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
        var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
        if (haveBoughtBefore == 0 && purchaseValue > 100)
            return false;

        return true;
    }

}