namespace FastEndpointTemplate.Shared.Test.Contracts;

public class WeatherForecastContractTest
{
    [Fact]
    public void WeatherForecastContract_Constructor()
    {
        var weatherForecast = new WeatherForecastContract();
        Assert.NotNull(weatherForecast);
        Assert.Null(weatherForecast.Date);
        Assert.Null(weatherForecast.TemperatureCelsius);
        Assert.Null(weatherForecast.TemperatureFahrenheit);
        Assert.Null(weatherForecast.Summary);
    }

    [Fact]
    public void WeatherForecastContract_Constructor_SetCelsius()
    {
        var guid = Guid.NewGuid();
        var weatherForecast = new WeatherForecastContract
        {
            Id = guid,
            Date = DateTime.Now,
            TemperatureCelsius = 0,
            Summary = "Summary"
        };

        Assert.NotNull(weatherForecast);
        Assert.NotNull(weatherForecast.Date);
        Assert.Equal(guid, weatherForecast.Id);
        Assert.Equal(0, weatherForecast.TemperatureCelsius);
        Assert.Equal(32, weatherForecast.TemperatureFahrenheit);
        Assert.Equal("Summary", weatherForecast.Summary);
    }

    [Fact]
    public void WeatherForecastContract_Constructor_SetFahrenheit()
    {
        var weatherForecast = new WeatherForecastContract
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            TemperatureFahrenheit = 32,
            Summary = "Summary"
        };

        Assert.NotNull(weatherForecast);
        Assert.NotNull(weatherForecast.Date);
        Assert.Equal(0, weatherForecast.TemperatureCelsius);
        Assert.Equal(32, weatherForecast.TemperatureFahrenheit);
        Assert.Equal("Summary", weatherForecast.Summary);
    }
}
