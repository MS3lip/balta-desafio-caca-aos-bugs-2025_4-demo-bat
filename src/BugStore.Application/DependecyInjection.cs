using Balta.Mediator;
using Balta.Mediator.Abstractions;
using Balta.Mediator.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BugStore.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IMediator, Mediator>();              

        services.AddMediator(typeof(DependecyInjection).Assembly);

        return services;
    }
}

