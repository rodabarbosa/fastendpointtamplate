using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers.WeatherForecasts;

public class GetWeatherForecastHandler : IGetWeatherForecastHandler
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public GetWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<WeatherForecastContract> Handle(Guid id)
    {
        var result = await _weatherForecastRepository.GetByIdAsync(id);

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
