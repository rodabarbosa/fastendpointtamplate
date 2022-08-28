using FastEndpointTemplate.Application.Converters;
using FastEndpointTemplate.Domain.Entities;
using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;

namespace FastEndpointTemplate.Application.Handlers.WeatherForecasts;

public class UpdateWeatherForecastHandler : IUpdateWeatherForecastHandler
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public UpdateWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<WeatherForecastContract> Handle(Guid id, WeatherForecastContract contract)
    {
        var weather = await GetWeatherAsync(id);

        await UpdateWeatherForecast(contract, weather);

        return weather.ToWeatherForecastContract();
    }

    private async Task<WeatherForecast> GetWeatherAsync(Guid id)
    {
        var weather = await _weatherForecastRepository.GetByIdAsync(id);

        NotFoundException.ThrowIf(weather is null, $"WeatherForecast with id {id} not found");

        return weather;
    }

    private Task UpdateWeatherForecast(WeatherForecastContract contract, WeatherForecast weather)
    {
        weather.Date = contract.Date.Value;
        weather.TemperatureCelsius = contract.TemperatureCelsius ?? default;
        weather.Summary = contract.Summary;

        return _weatherForecastRepository.UpdateAsync(weather);
    }
}
