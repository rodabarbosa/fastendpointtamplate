namespace FastEndpointTemplate.Application.Test.Handlers.WeatherForecasts;

public class UpdateWeatherForecastHandlerTest
{
    [Fact]
    public async Task ShouldUpdateWeatherForecast_Valid()
    {
        // Arrange
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        var handler = new UpdateWeatherForecastHandler(repository);

        var guid = Guid.Parse("43903282-c4b3-42f9-99cc-fd234ee6941d");

        var request = new WeatherForecastContract
        {
            Id = guid,
            Date = DateTime.Now,
            Summary = "Test",
            TemperatureCelsius = 0,
            TemperatureFahrenheit = 32
        };

        await handler.HandleAsync(guid, request);
        Assert.True(true);
    }
}
