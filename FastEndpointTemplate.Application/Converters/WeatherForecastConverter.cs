using FastEndpointTemplate.Domain.Entities;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Extensions;

namespace FastEndpointTemplate.Application.Converters;

public static class WeatherForecastConverter
{
    public static WeatherForecast? ToWeatherForecast(this WeatherForecastContract? contract)
    {
        if (contract is null)
            return default;

        var temperature = contract.TemperatureCelsius ?? default;

        return new WeatherForecast
        {
            Id = contract.Id ?? Guid.Empty,
            Date = contract.Date ?? default,
            TemperatureCelsius = temperature,
            Summary = contract.Summary
        };
    }

    public static WeatherForecastContract? ToWeatherForecastContract(this WeatherForecast? entity)
    {
        if (entity is null)
            return default;

        return new WeatherForecastContract
        {
            Id = entity.Id,
            Date = entity.Date,
            TemperatureCelsius = entity.TemperatureCelsius,
            TemperatureFahrenheit = entity.TemperatureCelsius.ToFahrenheit(),
            Summary = entity.Summary
        };
    }
}
