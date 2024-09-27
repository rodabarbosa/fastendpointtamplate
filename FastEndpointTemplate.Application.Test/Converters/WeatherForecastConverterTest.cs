namespace FastEndpointTemplate.Application.Test.Converters;

public class WeatherForecastConverterTest
{
    [Fact]
    public void Contract_Conversion_With_Should_Include_Fahreinheit()
    {
        // Arrange
        var weatherForecastDto = new WeatherForecastContract
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now,
            TemperatureCelsius = 0,
            Summary = "Summary"
        };

        weatherForecastDto.TemperatureFahrenheit
            .Should()
            .Be(32M);

        // Act
        var weatherForecast = weatherForecastDto.ToWeatherForecast();

        // Assert
        weatherForecast
            .Should()
            .NotBeNull();

        weatherForecast!.Id
            .Should()
            .Be(weatherForecastDto.Id.Value);

        weatherForecast.Date
            .Should()
            .Be(weatherForecastDto.Date);

        weatherForecast.TemperatureCelsius
            .Should()
            .Be(weatherForecastDto.TemperatureCelsius);

        weatherForecast.Summary
            .Should()
            .Be(weatherForecastDto.Summary);
    }

    [Fact]
    public void ToWeatherForecast_WithValidWeatherForecastDto_ReturnsNull()
    {
        // Arrange
        WeatherForecastContract? weatherForecastDto = null;

        // Act
        var weatherForecast = weatherForecastDto.ToWeatherForecast();

        // Assert
        weatherForecast
            .Should()
            .BeNull();
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
        weatherForecastContract
            .Should()
            .NotBeNull();

        weatherForecastContract!.Id
            .Should()
            .Be(weatherForecast.Id);

        weatherForecastContract.Date
            .Should()
            .Be(weatherForecast.Date);

        weatherForecastContract.TemperatureCelsius
            .Should()
            .Be(weatherForecast.TemperatureCelsius);

        weatherForecastContract.Summary
            .Should()
            .Be(weatherForecast.Summary);
    }

    [Fact]
    public void ToWeatherForecastContract_WithValidWeatherForecast_ReturnsNull()
    {
        // Arrange
        WeatherForecast? weatherForecast = null;

        // Act
        var weatherForecastContract = weatherForecast.ToWeatherForecastContract();

        // Assert
        weatherForecastContract
            .Should()
            .BeNull();
    }
}
