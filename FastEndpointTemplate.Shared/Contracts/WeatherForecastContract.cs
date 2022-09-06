using FastEndpointTemplate.Shared.Extensions;

namespace FastEndpointTemplate.Shared.Contracts;

/// <summary>
/// Weather forecast service contract.
/// </summary>
public class WeatherForecastContract
{
    /// <summary>
    /// Identification
    /// </summary>
    public Guid? Id { get; set; }

    /// <summary>
    /// Date/time of the forecast.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Temperature in celsius unit.
    /// </summary>
    public decimal? TemperatureCelsius { get; set; }

    /// <summary>
    /// Temperature in fahrenheit unit.
    /// </summary>
    public decimal? TemperatureFahrenheit
    {
        get => TemperatureCelsius?.ToFahrenheit();
        set => TemperatureCelsius = value?.ToCelsius();
    }

    /// <summary>
    /// Weather condition.
    /// </summary>
    public string? Summary { get; set; }
}
