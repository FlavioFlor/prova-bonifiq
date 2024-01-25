using ProvaPub.Contracts;
using ProvaPub.Services;

namespace ProvaPub;

public static class Bootstrapper
{
    public static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IRandomService, RandomService>();

        return services;
    }
}