using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PitStopConcurrency.Infrastructure.Persistence;
using PitStopConcurrency.Infrastructure.Repositories;
using PitStopConcurrency.Domain.Interfaces;

namespace PitStopConcurrency.Infrastructure.Configurations;

public static class InfraConfigurationExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Registrar DbContext
        services.AddDbContext<PitStopDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("PitStopDatabase")));

        // 2. Registrar Repositórios
        services.AddScoped<IRaceRepository, RaceRepository>();
        services.AddScoped<ICarRepository, CarRepository>();

        // 3. Registrar Serviços Externos
        // e.g. services.AddHttpClient<IWeatherApi, WeatherApiService>();

        // 4. Outras configurações de infra necessárias

        return services;
    }
}
