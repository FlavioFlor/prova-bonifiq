using ProvaPub.Contracts.Repositories;
using ProvaPub.Contracts.Services;
using ProvaPub.Dtos;
using ProvaPub.Entities;

namespace ProvaPub.Services;

public sealed class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<PaginatedResponseDto<Customer>> ListCustomers(PaginatedRequestDto request)
    {
        var productsCount = await _customerRepository.GetCustomerPaginatedCountAsync(request);

        var customers = await _customerRepository.GetCustomerPaginatedAsync(request);

        var paginatedResponse = new PaginatedResponseDto<Customer>(customers, productsCount);

        return paginatedResponse;
    }

    public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
    {
        if (customerId <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(customerId));
        }

        if (purchaseValue <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(purchaseValue));
        }

        //Business Rule: Non registered Customers cannot purchase
        var customer = await _customerRepository.FindAsync(customerId);
        if (customer == null)
        {
            throw new InvalidOperationException($"Customer Id {customerId} does not exists");
        }

        //Business Rule: A customer can purchase only a single time per month
        var baseDate = DateTime.UtcNow.AddMonths(-1);
        var ordersInThisMonth = await _customerRepository.CountOrdersInThisMonthAsync(customerId, baseDate);
        if (ordersInThisMonth > 0)
        {
            return false;
        }

        //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
        var haveBoughtBefore = await _customerRepository.CountCustomerInThisMonthAsync(customerId);
        return haveBoughtBefore != 0 || purchaseValue <= 100;
    }

}