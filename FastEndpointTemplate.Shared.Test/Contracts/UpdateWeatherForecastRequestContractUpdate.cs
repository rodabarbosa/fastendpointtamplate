namespace FastEndpointTemplate.Shared.Test.Contracts;

public class UpdateWeatherForecastRequestContractUpdate
{
    [Fact]
    public void UpdateWeatherForecastRequestContract_Constructor()
    {
        var request = new UpdateWeatherForecastRequestContract();
        Assert.NotNull(request);
        Assert.Null(request.Id);
        Assert.Null(request.WeatherForecast);
    }

    [Fact]
    public void UpdateWeatherForecastRequestContract_Properties()
    {
        var request = new UpdateWeatherForecastRequestContract
        {
            Id = Guid.NewGuid(),
            WeatherForecast = new WeatherForecastContract
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                TemperatureCelsius = 0,
                TemperatureFahrenheit = 32,
                Summary = "Test"
            }
        };

        Assert.NotNull(request);
        Assert.NotNull(request.Id);
        Assert.NotNull(request.WeatherForecast);
    }
}
