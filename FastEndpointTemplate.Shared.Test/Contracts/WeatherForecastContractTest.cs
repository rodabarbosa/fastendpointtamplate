namespace FastEndpointTemplate.Shared.Test.Contracts;

public class WeatherForecastContractTest
{
    [Fact]
    public void WeatherForecastContract_Constructor_Should_Success()
    {
        var weatherForecast = new WeatherForecastContract();

        weatherForecast.Date
            .Should()
            .BeNull();

        weatherForecast.TemperatureCelsius
            .Should()
            .BeNull();

        weatherForecast.TemperatureFahrenheit
            .Should()
            .BeNull();

        weatherForecast.Summary
            .Should()
            .BeNull();
    }

    [Fact]
    public void WeatherForecastContract_Constructor_SetCelsius()
    {
        var guid = Guid.NewGuid();
        var dt = DateTime.Now;
        var weatherForecast = new WeatherForecastContract
        {
            Id = guid,
            Date = dt,
            TemperatureCelsius = 0,
            Summary = "Summary"
        };

        weatherForecast.Date
            .Should()
            .BeSameDateAs(dt);

        weatherForecast.Id
            .Should()
            .Be(guid);

        weatherForecast.TemperatureCelsius
            .Should()
            .Be(0);

        weatherForecast.TemperatureFahrenheit
            .Should()
            .Be(32M);

        weatherForecast.Summary
            .Should()
            .Be("Summary");
    }

    [Fact]
    public void WeatherForecastContract_Constructor_SetFahrenheit()
    {
        var id = Guid.NewGuid();
        var dt = DateTime.Now;
        var weatherForecast = new WeatherForecastContract
        {
            Id = id,
            Date = dt,
            TemperatureFahrenheit = 32,
            Summary = "Summary"
        };

        weatherForecast.Date
            .Should()
            .BeSameDateAs(dt);

        weatherForecast.TemperatureCelsius
            .Should()
            .Be(0);

        weatherForecast.TemperatureFahrenheit
            .Should()
            .Be(32M);

        weatherForecast.Summary
            .Should()
            .Be("Summary");
    }
}
