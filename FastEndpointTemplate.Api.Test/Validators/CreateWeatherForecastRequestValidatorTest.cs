namespace FastEndpointTemplate.Api.Test.Validators;

public class CreateWeatherForecastRequestValidatorTest
{
    private readonly CreateWeatherForecastRequestValidator _validator;

    public CreateWeatherForecastRequestValidatorTest()
    {
        _validator = new CreateWeatherForecastRequestValidator();
    }

    [Fact]
    public void CreateWeatherForecast_Valid()
    {
        var weather = new CreateWeatherForecastRequestContract
        {
            WeatherForecast = new WeatherForecastContract
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(-1),
                TemperatureCelsius = 0,
                TemperatureFahrenheit = 32,
                Summary = "Summary Valid"
            }
        };

        var result = _validator.Validate(weather);

        Assert.True(result.IsValid);
    }
}
