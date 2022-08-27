using FastEndpointTemplate.Domain.Entities;
using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Persistence.Contexts;

namespace FastEndpointTemplate.Persistence.Repositories;

public class WeatherForecastRepository : BaseRepository<WeatherForecast>, IWeatherForecastRepository
{
    public WeatherForecastRepository(ApplicationContext context) : base(context)
    {
    }
}