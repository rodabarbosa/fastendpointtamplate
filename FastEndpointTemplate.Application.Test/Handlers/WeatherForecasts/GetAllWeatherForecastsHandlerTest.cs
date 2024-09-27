using FastEndpointTemplate.Application.Handlers;

namespace FastEndpointTemplate.Application.Test.Handlers.WeatherForecasts;

public class GetAllWeatherForecastsHandlerTest
{
    private readonly IGetAllWeatherForecastHandler _handler;

    public GetAllWeatherForecastsHandlerTest()
    {
        var context = ContextUtil.GetContext();
        var repository = new WeatherForecastRepository(context);
        _handler = new GetAllWeatherForecastHandler(repository);
    }

    [Fact]
    public async Task Request_Should_Return()
    {
        var result = await _handler.HandleAsync(null, default);

        result.Should()
            .NotBeNull();
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
    public async Task Query_Should_Return_Something(string key, string value, string operation)
    {
        var param = $"dtInsert=[Equal,0]&dtUpdate=[Equal,0]&{key}=[{operation},{value}]";

        var result = await _handler.HandleAsync(param, default);

        result
            .Should()
            .NotBeNull();
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
    public async Task Query_Should_Return(string key, string value, string operation)
    {
        var param = $"dtInsert=[Equal,0]&dtUpdate=[Equal,0]&{key}=[{operation},{value}]";

        var result = await _handler.HandleAsync(param, default);
        result
            .Should()
            .NotBeNull();
    }
}
