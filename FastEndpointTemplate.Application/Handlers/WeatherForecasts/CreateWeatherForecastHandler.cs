using FastEndpointTemplate.Application.Converters;
using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers.WeatherForecasts;

public sealed class CreateWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    : ICreateWeatherForecastHandler
{
    public async Task<WeatherForecastContract?> HandleAsync(WeatherForecastContract contract, CancellationToken cancellationToken)
    {
        var weather = contract.ToWeatherForecast();

        await weatherForecastRepository.AddAsync(weather, cancellationToken);

        return weather?.ToWeatherForecastContract();
    }
}
