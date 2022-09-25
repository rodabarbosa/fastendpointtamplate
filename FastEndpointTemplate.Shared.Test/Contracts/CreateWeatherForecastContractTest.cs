namespace FastEndpointTemplate.Shared.Test.Contracts;

public class CreateWeatherForecastContractTest
{
    [Fact]
    public void Create_NullProperty()
    {
        var testObject = new CreateWeatherForecastRequestContract();

        Assert.NotNull(testObject);
        Assert.Null(testObject.WeatherForecast);
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

        Assert.NotNull(testObject);
        Assert.NotNull(testObject.WeatherForecast);
        Assert.Equal(32, testObject.WeatherForecast.TemperatureFahrenheit);
    }
}
