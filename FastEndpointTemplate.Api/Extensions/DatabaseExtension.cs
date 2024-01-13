using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Persistence.Contexts;
using FastEndpointTemplate.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FastEndpointTemplate.Api.Extensions;

public static class DatabaseExtension
{
    public static void AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationContext>(o => o.UseInMemoryDatabase(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
    }
}
