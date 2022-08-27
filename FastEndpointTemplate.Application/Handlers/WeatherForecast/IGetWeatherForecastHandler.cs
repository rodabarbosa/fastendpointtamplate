using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers.WeatherForecast;

public interface IGetWeatherForecastHandler
{
    Task<IEnumerable<WeatherForecastContract>> Handle(string param);
}
