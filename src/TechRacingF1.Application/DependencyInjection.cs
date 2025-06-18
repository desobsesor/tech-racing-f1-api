using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TechRacingF1.Application.Common.Behaviors;
using TechRacingF1.Application.Features.Simulations;

namespace TechRacingF1.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // Register FluentValidation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Register MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            // Adding pipeline behaviors
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        services.AddScoped<SimulateStrategiesUseCase>();

        return services;
    }
}
