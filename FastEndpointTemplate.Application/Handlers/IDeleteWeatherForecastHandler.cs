namespace FastEndpointTemplate.Application.Handlers;

public interface IDeleteWeatherForecastHandler
{
    Task HandleAsync(Guid id, CancellationToken cancellationToken);
}
