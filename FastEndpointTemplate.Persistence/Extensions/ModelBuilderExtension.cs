using FastEndpointTemplate.Domain.Entities;
using FastEndpointTemplate.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;

namespace FastEndpointTemplate.Persistence.Extensions;

public static class ModelBuilderExtension
{
    public static void SetSeeds(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecast>()
            .HasData(WeatherForecastSeed.GetSeeds());

        modelBuilder.Entity<User>()
            .HasData(UserSeed.GetSeeds());
    }
}
