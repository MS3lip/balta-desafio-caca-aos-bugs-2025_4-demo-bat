using BugStore.Domain.Contexts.Customers.Repositories;
using BugStore.Domain.Contexts.Orders.Repositories;
using BugStore.Domain.Contexts.Products.Repositories;
using BugStore.Infrastructure.Contexts.Customers;
using BugStore.Infrastructure.Contexts.Orders;
using BugStore.Infrastructure.Contexts.Products;
using Microsoft.Extensions.DependencyInjection;

namespace BugStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {                
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();        
        services.AddTransient<IOrderRepository, OrderRepository>();        

        return services;
    }
}

