using ProvaPub.Contracts.Repositories;
using ProvaPub.Contracts.Services;
using ProvaPub.Repositories;
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
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IProductReposiory, ProductReposiory>();
        services.AddScoped<IOrderReposiory, OrderReposiory>();

        return services;
    }

    
}