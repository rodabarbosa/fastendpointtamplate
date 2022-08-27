using FastEndpoints;

namespace FastEndpointTemplate.Shared.Contracts;

public class CreateWeatherForecastRequestContract
{
    [FromBody] public WeatherForecastContract? WeatherForecast { get; set; }
}
