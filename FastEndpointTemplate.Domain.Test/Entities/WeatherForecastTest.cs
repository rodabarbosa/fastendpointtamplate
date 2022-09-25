namespace FastEndpointTemplate.Domain.Test.Entities;

public class WeatherForecastTest
{
    [Fact]
    public void Create_Constructor()
    {
        var weatherForecast = new WeatherForecast();

        Assert.NotNull(weatherForecast);
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

        Assert.NotNull(weatherForecast);
        Assert.Equal(guid, weatherForecast.Id);
        Assert.Equal(date, weatherForecast.Date);
        Assert.Equal(0, weatherForecast.TemperatureCelsius);
        Assert.Equal(summary, weatherForecast.Summary);
    }
}
