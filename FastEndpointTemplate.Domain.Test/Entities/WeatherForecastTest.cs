namespace FastEndpointTemplate.Domain.Test.Entities;

public class WeatherForecastTest
{
    [Fact]
    public void Create_Constructor()
    {
        var weatherForecast = new WeatherForecast();

        weatherForecast.Should()
            .NotBeNull();
    }

    [Fact]
    public void Create_Properties()
    {
        var guid = Guid.NewGuid();
        var date = DateTime.Now;
        var summary = "Summary";

        var weatherForecast = new WeatherForecast
        {
            Id = guid,
            Date = date,
            TemperatureCelsius = 0,
            Summary = summary
        };

        weatherForecast.Should()
            .NotBeNull();

        weatherForecast.Id
            .Should()
            .Be(guid);

        weatherForecast.Date
            .Should()
            .Be(date);

        weatherForecast.TemperatureCelsius
            .Should()
            .Be(0);

        weatherForecast.Summary
            .Should()
            .Be(summary);
    }
}
