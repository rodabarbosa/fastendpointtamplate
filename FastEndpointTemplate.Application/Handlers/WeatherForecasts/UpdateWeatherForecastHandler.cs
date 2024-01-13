using FastEndpointTemplate.Application.Converters;
using FastEndpointTemplate.Domain.Entities;
using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;

namespace FastEndpointTemplate.Application.Handlers.WeatherForecasts;

public sealed class UpdateWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    : IUpdateWeatherForecastHandler
{
    public async Task<WeatherForecastContract> HandleAsync(Guid id, WeatherForecastContract contract, CancellationToken cancellationToken)
    {
        BadRequestException.ThrowIf(id != contract.Id, "The id in the route must match the id in the body");

        var weather = await GetWeatherAsync(id, cancellationToken);

        await UpdateWeatherForecast(contract, weather, cancellationToken);

        return weather!.ToWeatherForecastContract()!;
    }

    private async Task<WeatherForecast> GetWeatherAsync(Guid id, CancellationToken cancellationToken)
    {
        var weather = await weatherForecastRepository.GetByIdAsync(id, cancellationToken);

        NotFoundException.ThrowIf(weather is null, $"WeatherForecast with id {id} not found");

        return weather!;
    }

    private Task UpdateWeatherForecast(WeatherForecastContract contract, WeatherForecast weather, CancellationToken cancellationToken)
    {
        weather.Date = contract.Date!.Value;
        weather.TemperatureCelsius = contract.TemperatureCelsius ?? default;
        weather.Summary = contract.Summary;

        return weatherForecastRepository.UpdateAsync(weather, cancellationToken);
    }
}
