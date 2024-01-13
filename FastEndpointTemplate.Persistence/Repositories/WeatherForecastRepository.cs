using FastEndpointTemplate.Domain.Entities;
using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Persistence.Contexts;

namespace FastEndpointTemplate.Persistence.Repositories;

public class WeatherForecastRepository(ApplicationContext context)
    : BaseRepository<WeatherForecast>(context), IWeatherForecastRepository;
