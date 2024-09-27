namespace FastEndpointTemplate.Shared.Test.Contracts;

public class CreateWeatherForecastContractTest
{
    [Fact]
    public void Create_NullProperty()
    {
        var testObject = new CreateWeatherForecastRequestContract();

        testObject
            .Should()
            .NotBeNull();

        testObject.WeatherForecast
            .Should()
            .BeNull();
    }

    [Fact]
    public void Create_WithProperty()
    {
        var testObject = new CreateWeatherForecastRequestContract
        {
            WeatherForecast = new WeatherForecastContract
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                TemperatureCelsius = 0,
                Summary = "TEST"
            }
        };

        testObject
            .Should()
            .NotBeNull();

        testObject.WeatherForecast
            .Should()
            .NotBeNull();

        testObject.WeatherForecast
            .TemperatureFahrenheit
            .Should()
            .Be(32);
    }
}
