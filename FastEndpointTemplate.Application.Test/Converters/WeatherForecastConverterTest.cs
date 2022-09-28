namespace FastEndpointTemplate.Application.Test.Converters;

public class WeatherForecastConverterTest
{
    [Fact]
    public void ToWeatherForecast_WithValidWeatherForecastDto_ReturnsWeatherForecast()
    {
        // Arrange
        var weatherForecastDto = new WeatherForecastContract
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            TemperatureCelsius = 0,
            Summary = "Summary"
        };

        // Act
        var weatherForecast = weatherForecastDto.ToWeatherForecast();

        // Assert
        Assert.NotNull(weatherForecast);
        Assert.Equal(weatherForecastDto.Id, weatherForecast.Id);
        Assert.Equal(weatherForecastDto.Date, weatherForecast.Date);
        Assert.Equal(weatherForecastDto.TemperatureCelsius, weatherForecast.TemperatureCelsius);
        Assert.Equal(weatherForecastDto.Summary, weatherForecast.Summary);
    }

    [Fact]
    public void ToWeatherForecast_WithValidWeatherForecastDto_ReturnsNull()
    {
        // Arrange
        WeatherForecastContract weatherForecastDto = null;

        // Act
        var weatherForecast = weatherForecastDto.ToWeatherForecast();

        // Assert
        Assert.Null(weatherForecast);
    }

    [Fact]
    public void ToWeatherForecastContract_WithValidWeatherForecast_ReturnsWeatherForecastContract()
    {
        // Arrange
        var weatherForecast = new WeatherForecast
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Today,
            TemperatureCelsius = 0,
            Summary = "Summary"
        };

        // Act
        var weatherForecastContract = weatherForecast.ToWeatherForecastContract();

        // Assert
        Assert.NotNull(weatherForecastContract);
        Assert.Equal(weatherForecast.Id, weatherForecastContract.Id);
        Assert.Equal(weatherForecast.Date, weatherForecastContract.Date);
        Assert.Equal(weatherForecast.TemperatureCelsius, weatherForecastContract.TemperatureCelsius);
        Assert.Equal(weatherForecast.Summary, weatherForecastContract.Summary);
    }

    [Fact]
    public void ToWeatherForecastContract_WithValidWeatherForecast_ReturnsNull()
    {
        // Arrange
        WeatherForecast weatherForecast = null;

        // Act
        var weatherForecastContract = weatherForecast.ToWeatherForecastContract();

        // Assert
        Assert.Null(weatherForecastContract);
    }
}
