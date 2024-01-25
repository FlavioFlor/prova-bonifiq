using ProvaPub.Entities;
using ProvaPub.Fixed;

namespace ProvaPub.Contracts.Services;

public interface IOrderService
{
    Task<Order> PayOrder(PaymentMethod paymentMethod, decimal paymentValue, int customerId);
}