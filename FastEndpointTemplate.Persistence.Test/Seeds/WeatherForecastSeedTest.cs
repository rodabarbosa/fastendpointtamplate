namespace FastEndpointTemplate.Persistence.Test.Seeds;

public class WeatherForecastSeedTest
{
    [Fact]
    public void GetWeatherForecastSeed_Valid()
    {
        var result = WeatherForecastSeed.GetSeeds();
        Assert.NotEmpty(result);
    }
}
