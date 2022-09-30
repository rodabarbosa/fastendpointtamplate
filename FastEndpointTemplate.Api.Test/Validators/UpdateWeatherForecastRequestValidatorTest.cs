namespace FastEndpointTemplate.Api.Test.Validators;

public class UpdateWeatherForecastRequestValidatorTest
{
    private readonly UpdateWeatherForecastRequestValidator _validator;

    public UpdateWeatherForecastRequestValidatorTest()
    {
        _validator = new UpdateWeatherForecastRequestValidator();
    }

    [Fact]
    public void UpdateWeather_Valid()
    {
        var guid = Guid.NewGuid();
        var weather = new UpdateWeatherForecastRequestContract
        {
            Id = guid,
            WeatherForecast = new WeatherForecastContract
            {
                Id = guid,
                Date = DateTime.Now.AddDays(-1),
                TemperatureCelsius = 0,
                TemperatureFahrenheit = 32,
                Summary = "Summary"
            }
        };

        var result = _validator.Validate(weather);

        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("3b901011-1677-4cd2-8d97-41b3ad43d28c", "2030-01-01 00:00:00", 0, 32)]
    [InlineData("3b901011-1677-4cd2-8d97-41b3ad43d28c", "2022-01-01 00:00:00", 6000, 60000)]
    public void UpdateWeather_Invalid(Guid guid, DateTime date, decimal celsius, decimal fahrenheit)
    {
        var weather = new UpdateWeatherForecastRequestContract
        {
            Id = guid,
            WeatherForecast = new WeatherForecastContract
            {
                Id = guid,
                Date = date,
                TemperatureCelsius = celsius,
                TemperatureFahrenheit = fahrenheit,
                Summary = "Summary"
            }
        };

        var result = _validator.Validate(weather);

        Assert.False(result.IsValid);
    }
}
