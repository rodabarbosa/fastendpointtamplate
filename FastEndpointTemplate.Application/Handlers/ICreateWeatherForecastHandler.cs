using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers;

public interface ICreateWeatherForecastHandler
{
    Task<WeatherForecastContract> HandleAsync(WeatherForecastContract contract);
}
