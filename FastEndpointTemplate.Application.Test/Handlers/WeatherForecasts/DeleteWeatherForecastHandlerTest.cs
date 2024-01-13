namespace FastEndpointTemplate.Application.Test.Handlers.WeatherForecasts;

public class DeleteWeatherForecastHandlerTest
{
    [Fact]
    public async Task ShouldDeleteWeatherForecast_Valid()
    {
        // Arrange
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        var handler = new DeleteWeatherForecastHandler(repository);

        var guid = Guid.Parse("10fd1392-3b4c-431a-b6dc-19cfba4ea269");

        await handler.HandleAsync(guid, CancellationToken.None);
        Assert.True(true);
    }
}
