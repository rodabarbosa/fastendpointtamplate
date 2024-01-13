namespace FastEndpointTemplate.Application.Test.Handlers.WeatherForecasts;

public class CreateWeatherForecastHandlerTest
{
    [Fact]
    public async Task ShouldCreateWeatherForecast_Valid()
    {
        // Arrange
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        var handler = new CreateWeatherForecastHandler(repository);

        var request = new WeatherForecastContract
        {
            Id = Guid.NewGuid(),
            Date = DateTime.Now.AddHours(-1),
            TemperatureCelsius = 0,
            TemperatureFahrenheit = 32,
            Summary = "Freezing"
        };

        var response = await handler.HandleAsync(request, CancellationToken.None);
        response.Should()
            .NotBeNull();
    }
}
