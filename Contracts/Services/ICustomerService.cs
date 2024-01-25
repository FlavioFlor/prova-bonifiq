using ProvaPub.Dtos;
using ProvaPub.Entities;

namespace ProvaPub.Contracts.Services;

public interface ICustomerService
{
    Task<PaginatedResponseDto<Customer>> ListCustomers(PaginatedRequestDto request);
    Task<bool> CanPurchase(int customerId, decimal purchaseValue);
}