using FastEndpoints;

namespace FastEndpointTemplate.Shared.Contracts;

public class UpdateWeatherForecastRequestContract
{
    public Guid? Id { get; set; }
    [FromBody] public WeatherForecastContract? WeatherForecast { get; set; }
}
