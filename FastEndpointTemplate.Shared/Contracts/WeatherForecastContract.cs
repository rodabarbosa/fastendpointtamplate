using FastEndpointTemplate.Shared.Extensions;

namespace FastEndpointTemplate.Shared.Contracts;

/// <summary>
/// Weather forecast service contract.
/// </summary>
public class WeatherForecastContract(Guid? id, DateTime? date, decimal? temperatureCelsius, decimal? temperatureFahrenheit, string? summary)
{
    public WeatherForecastContract()
        : this(default, default, default, default, default)
    {
    }

    /// <summary>
    /// Identification
    /// </summary>
    public Guid? Id { get; set; } = id;

    /// <summary>
    /// Date/time of the forecast.
    /// </summary>
    public DateTime? Date { get; set; } = date;

    /// <summary>
    /// Temperature in celsius unit.
    /// </summary>
    public decimal? TemperatureCelsius
    {
        get => _celsius;
        set
        {
            _celsius = value;
            _fahrenheit = value?.ToFahrenheit();
        }
    }

    /// <summary>
    /// Temperature in fahrenheit unit.
    /// </summary>
    public decimal? TemperatureFahrenheit
    {
        get => _fahrenheit;
        set
        {
            _fahrenheit = value;
            _celsius = value?.ToCelsius();
        }
    }

    /// <summary>
    /// Weather condition.
    /// </summary>
    public string? Summary { get; set; } = summary;

    private decimal? _fahrenheit = temperatureFahrenheit;
    private decimal? _celsius = temperatureCelsius;
}
