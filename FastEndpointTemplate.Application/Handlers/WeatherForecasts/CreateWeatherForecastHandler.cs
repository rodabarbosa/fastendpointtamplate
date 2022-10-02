using FastEndpointTemplate.Application.Converters;
using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers.WeatherForecasts;

public class CreateWeatherForecastHandler : ICreateWeatherForecastHandler
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public CreateWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<WeatherForecastContract?> HandleAsync(WeatherForecastContract contract)
    {
        var weather = contract.ToWeatherForecast();

        await _weatherForecastRepository.AddAsync(weather);

        return weather?.ToWeatherForecastContract();
    }
}
