using FastEndpoints;

namespace FastEndpointTemplate.Shared.Contracts;

public class UpdateWeatherForecastRequestContract(Guid? id, WeatherForecastContract? weatherForecast)
{
    public UpdateWeatherForecastRequestContract()
        : this(default, default)
    {
    }

    public Guid? Id { get; set; } = id;
    [FromBody] public WeatherForecastContract? WeatherForecast { get; set; } = weatherForecast;
}
