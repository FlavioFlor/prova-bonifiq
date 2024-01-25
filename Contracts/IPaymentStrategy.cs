using ProvaPub.Entities;

namespace ProvaPub.Contracts;

public interface IPaymentStrategy
{
    Task<Order> Pay(decimal paymentValue, int customerId);
}