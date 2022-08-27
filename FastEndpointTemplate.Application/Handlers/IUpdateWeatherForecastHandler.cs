using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers;

public interface IUpdateWeatherForecastHandler
{
    Task<WeatherForecastContract> Handle(Guid id, WeatherForecastContract contract);
}
