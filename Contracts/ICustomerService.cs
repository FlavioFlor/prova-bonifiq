using ProvaPub.Dtos;
using ProvaPub.Models;

namespace ProvaPub.Contracts;

public interface ICustomerService
{
    PaginatedResponseDto<Customer> ListCustomers(PaginatedRequestDto request);
    Task<bool> CanPurchase(int customerId, decimal purchaseValue);
}