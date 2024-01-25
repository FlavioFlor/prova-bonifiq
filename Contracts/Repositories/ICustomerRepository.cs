using ProvaPub.Dtos;
using ProvaPub.Entities;

namespace ProvaPub.Contracts.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> FindAsync(int customerId);
    Task<int> CountOrdersInThisMonthAsync(int customerId, DateTime baseDate);
    Task<int> CountCustomerInThisMonthAsync(int customerId);
    Task<IEnumerable<Customer>> GetCustomerPaginatedAsync(PaginatedRequestDto request);
    Task<int> GetCustomerPaginatedCountAsync(PaginatedRequestDto request);
}