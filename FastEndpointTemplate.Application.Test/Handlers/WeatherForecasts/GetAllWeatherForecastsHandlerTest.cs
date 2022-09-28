namespace FastEndpointTemplate.Application.Test.Handlers.WeatherForecasts;

public class GetAllWeatherForecastsHandlerTest
{
    [Fact]
    public async Task ShouldGetAllWeatherForecasts_Valid()
    {
        // Arrange
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        var handler = new GetAllWeatherForecastHandler(repository);

        var result = await handler.Handle(null);
        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("date", "2030-01-01 00:00:00", "Equal")]
    [InlineData("date", "2030-01-01 00:00:00", "NotEqual")]
    [InlineData("date", "2030-01-01 00:00:00", "GreaterThan")]
    [InlineData("date", "2030-01-01 00:00:00", "GreaterThanOrEqual")]
    [InlineData("date", "1900-01-01 00:00:00", "LessThan")]
    [InlineData("date", "1900-01-01 00:00:00", "LessThanOrEqual")]
    [InlineData("date", "1900-01-01 00:00:00", "Fail")]
    [InlineData("temperatureFahrenheit", "2000", "Equal")]
    [InlineData("temperatureFahrenheit", "2000", "NotEqual")]
    [InlineData("temperatureFahrenheit", "2000", "GreaterThan")]
    [InlineData("temperatureFahrenheit", "2000", "GreaterThanOrEqual")]
    [InlineData("temperatureFahrenheit", "-2000", "LessThan")]
    [InlineData("temperatureFahrenheit", "-2000", "LessThanOrEqual")]
    [InlineData("temperatureFahrenheit", "-2000", "Fail")]
    [InlineData("temperatureCelsius", "2000", "Equal")]
    [InlineData("temperatureCelsius", "2000", "NotEqual")]
    [InlineData("temperatureCelsius", "2000", "GreaterThan")]
    [InlineData("temperatureCelsius", "2000", "GreaterThanOrEqual")]
    [InlineData("temperatureCelsius", "-2000", "LessThan")]
    [InlineData("temperatureCelsius", "-2000", "LessThanOrEqual")]
    [InlineData("temperatureCelsius", "-2000", "Fail")]
    public async Task ShouldGetWeatherByQuery(string key, string value, string operation)
    {
        // Arrange
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        var handler = new GetAllWeatherForecastHandler(repository);

        var param = $"dtInsert=[Equal,0]&dtUpdate=[Equal,0]&{key}=[{operation},{value}]";

        var result = await handler.Handle(param);
        Assert.NotNull(result);
    }
}
