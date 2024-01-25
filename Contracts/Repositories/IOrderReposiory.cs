using ProvaPub.Entities;

namespace ProvaPub.Contracts.Repositories;

public interface IOrderReposiory
{
    Task AddOrder(Order order);
}