using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers;

public interface IGetAllWeatherForecastHandler
{
    Task<List<WeatherForecastContract>>? HandleAsync(string? param);
}
