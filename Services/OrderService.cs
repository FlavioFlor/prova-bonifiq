using ProvaPub.Contracts;
using ProvaPub.Contracts.Repositories;
using ProvaPub.Contracts.Services;
using ProvaPub.Entities;
using ProvaPub.Fixed;
using ProvaPub.Models;

namespace ProvaPub.Services;

public sealed class OrderService : IOrderService
{
    private readonly IOrderReposiory _orderReposiory;
    private readonly ICustomerRepository _customerRepository;

    public OrderService(IOrderReposiory orderReposiory,
                        ICustomerRepository customerRepository)
    {
        _orderReposiory = orderReposiory;
        _customerRepository = customerRepository;
    }

    public async Task<Order> PayOrder(PaymentMethod paymentMethod, decimal paymentValue, int customerId)
    {
        var customer = await _customerRepository.FindAsync(customerId);

        if (customer is null)
        {
            throw new ApplicationException("Cliente não encontrado.");
        }

        var paymentStrategy = GetPaymentStrategy(paymentMethod);

        var order = await paymentStrategy.Pay(paymentValue, customer.Id);

        await _orderReposiory.AddOrder(order);

        return order;
    }

    private static IPaymentStrategy GetPaymentStrategy(PaymentMethod paymentMethod)
    {
        return paymentMethod switch
        {
            PaymentMethod.Pix => new Pix(),
            PaymentMethod.Creditcard => new CreditCard(),
            PaymentMethod.Paypal => new Paypal(),
            _ => throw new ArgumentOutOfRangeException(nameof(paymentMethod), paymentMethod, null)
        };
    }
}