using ProvaPub.Contracts;
using ProvaPub.Entities;

namespace ProvaPub.Models;

public sealed class Pix : IPaymentStrategy
{
    public Task<Order> Pay(decimal paymentValue, int customerId)
    {
        return Task.FromResult(new Order(paymentValue, customerId));
    }
}