using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Shared.Exceptions;

namespace FastEndpointTemplate.Application.Handlers.WeatherForecasts;

public class DeleteWeatherForecastHandler : IDeleteWeatherForecastHandler
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public DeleteWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task Handle(Guid id)
    {
        var weather = await _weatherForecastRepository.GetByIdAsync(id);

        NotFoundException.ThrowIf(weather is null, $"WeatherForecast with id {id} not found");

        await _weatherForecastRepository.DeleteAsync(weather);
    }
}
