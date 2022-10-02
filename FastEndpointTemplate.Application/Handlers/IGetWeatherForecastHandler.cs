using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers;

public interface IGetWeatherForecastHandler
{
    Task<WeatherForecastContract> HandleAsync(Guid id);
}
