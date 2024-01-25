using Moq;
using Moq.AutoMock;
using ProvaPub.Contracts.Repositories;
using ProvaPub.Services;
using ProvaPub.Tests.Mocks;
using Xunit;

namespace ProvaPub.Tests.Units;

public sealed class CustomerServiceTests
{
    private readonly CustomerService _establishContext;
    private readonly AutoMocker _mocker;

    public CustomerServiceTests()
    {
        _mocker = new AutoMocker();
        _establishContext = _mocker.CreateInstance<CustomerService>();
    }


    [Fact(DisplayName = "CanPurchase_ReturnsTrue_WhenCustomerCanPurchase")]
    public async Task CanPurchase_ReturnsTrue_WhenCustomerCanPurchase()
    {
        // Arrange
        var customer = CustomerMock.GetDefaultInstance();

        _mocker.GetMock<ICustomerRepository>()
            .Setup(repository => repository.FindAsync(It.IsAny<int>()))
            .ReturnsAsync(customer!);

        _mocker.GetMock<ICustomerRepository>()
            .Setup(repository => repository.CountOrdersInThisMonthAsync(It.IsAny<int>(), It.IsAny<DateTime>()))
            .ReturnsAsync(It.IsAny<int>());

        _mocker.GetMock<ICustomerRepository>()
            .Setup(repository => repository.CountCustomerInThisMonthAsync(It.IsAny<int>()))
            .ReturnsAsync(It.IsAny<int>());

        // Act
        var result = await _establishContext.CanPurchase(customer.Id, 50);

        // Assert
        Assert.True(result);
    }
}