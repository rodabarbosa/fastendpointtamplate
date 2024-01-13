using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Shared.Exceptions;

namespace FastEndpointTemplate.Application.Handlers.WeatherForecasts;

public sealed class DeleteWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    : IDeleteWeatherForecastHandler
{
    public async Task HandleAsync(Guid id, CancellationToken cancellationToken)
    {
        var weather = await weatherForecastRepository.GetByIdAsync(id, cancellationToken);

        NotFoundException.ThrowIf(weather is null, $"WeatherForecast with id {id} not found");

        await weatherForecastRepository.DeleteAsync(weather, cancellationToken);
    }
}
