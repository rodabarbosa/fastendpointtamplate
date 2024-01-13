using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers.WeatherForecasts;

public sealed class GetWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    : IGetWeatherForecastHandler
{
    public async Task<WeatherForecastContract?> HandleAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await weatherForecastRepository.GetByIdAsync(id, cancellationToken);

        if (result is null)
            return default;

        return new WeatherForecastContract
        {
            Id = result.Id,
            Date = result.Date,
            TemperatureCelsius = result.TemperatureCelsius,
            Summary = result.Summary
        };
    }
}
