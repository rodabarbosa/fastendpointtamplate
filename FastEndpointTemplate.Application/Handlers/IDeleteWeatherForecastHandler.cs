namespace FastEndpointTemplate.Application.Handlers;

public interface IDeleteWeatherForecastHandler
{
    Task Handle(Guid id);
}
