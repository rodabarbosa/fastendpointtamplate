namespace FastEndpointTemplate.Application.Test.Handlers.WeatherForecasts;

public class GetWeatherForecastHandlerTest
{
    [Theory]
    [InlineData("43903282-c4b3-42f9-99cc-fd234ee6941d", true)]
    [InlineData("43903282-c4b3-42f9-99cc-fd234ee69400", false)]
    public async Task ShouldGetWeatherForecast(Guid guid, bool expected)
    {
        // Arrange
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        var handler = new GetWeatherForecastHandler(repository);

        var result = await handler.HandleAsync(guid);

        if (expected)
            Assert.NotNull(result);
        else
            Assert.Null(result);
    }
}
