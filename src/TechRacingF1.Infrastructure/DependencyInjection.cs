using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechRacingF1.Domain.Ports;
using TechRacingF1.Infrastructure.Persistence;
using TechRacingF1.Infrastructure.Persistence.Repositories;

namespace TechRacingF1.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        // Register repositories
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<ISimulationRepository, SimulationRepository>();
        services.AddScoped<ITyreRepository, TyreRepository>();
        services.AddScoped<IStrategyRepository, StrategyRepository>();
        services.AddScoped<IStrategyDetailRepository, StrategyDetailRepository>();
        services.AddScoped<ISimulationLogRepository, SimulationLogRepository>();
        services.AddScoped<IPitStopRepository, PitStopRepository>();
        services.AddScoped<IWeatherRepository, WeatherRepository>();
        services.AddScoped<ITrackRepository, TrackRepository>();

        return services;
    }
}