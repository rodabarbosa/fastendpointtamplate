namespace FastEndpointTemplate.Api.Test.Validators;

public class DeleteWeatherForecastRequestValidatorTest
{
    private readonly DeleteWeatherForecastRequestValidator _validator;

    public DeleteWeatherForecastRequestValidatorTest()
    {
        _validator = new DeleteWeatherForecastRequestValidator();
    }

    [Fact]
    public void DeleteWeather_Valid()
    {
        var weather = new DeleteWeatherForecastRequestContract
        {
            Id = Guid.NewGuid()
        };

        var result = _validator.Validate(weather);

        Assert.True(result.IsValid);
    }

    [Fact]
    public void DeleteWeather_Invalid()
    {
        var weather = new DeleteWeatherForecastRequestContract
        {
            Id = Guid.Empty
        };

        var result = _validator.Validate(weather);

        Assert.False(result.IsValid);
    }
}
