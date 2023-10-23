using System.Reflection;
using CQRS.Abstractions.Commands;
using CQRS.Abstractions.Queries;
using CQRS.Commands;
using CQRS.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, params Type[] types)
    {
        var assemblies = types.Select(type => type.GetTypeInfo().Assembly);

        foreach (var assembly in assemblies)
        {
            services.AddMediatR(assembly);
        }

        services.AddScoped<ICommandBus, CommandBus>();
        services.AddScoped<IQueryBus, QueryBus>();

        return services;
    }
}