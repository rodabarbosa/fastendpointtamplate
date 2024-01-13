using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers;

public interface IUpdateWeatherForecastHandler
{
    Task<WeatherForecastContract> HandleAsync(Guid id, WeatherForecastContract contract, CancellationToken cancellationToken);
}
