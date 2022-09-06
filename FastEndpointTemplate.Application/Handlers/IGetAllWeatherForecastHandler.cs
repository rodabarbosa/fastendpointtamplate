using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers;

public interface IGetAllWeatherForecastHandler
{
    Task<IEnumerable<WeatherForecastContract>> Handle(string? param);
}
