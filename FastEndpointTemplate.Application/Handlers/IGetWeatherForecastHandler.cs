using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers;

public interface IGetWeatherForecastHandler
{
    Task<WeatherForecastContract> Handle(Guid id);
}
