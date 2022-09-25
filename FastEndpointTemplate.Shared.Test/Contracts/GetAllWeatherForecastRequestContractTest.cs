namespace FastEndpointTemplate.Shared.Test.Contracts;

public class GetAllWeatherForecastRequestContractTest
{
    [Fact]
    public void GetAllWeatherForecastRequestContract_Constructor()
    {
        var request = new GetAllWeatherForecastRequestContract();
        Assert.NotNull(request);
        Assert.Null(request.Params);
    }

    [Fact]
    public void GetAllWeatherForecastRequestContract_Properties()
    {
        var request = new GetAllWeatherForecastRequestContract
        {
            Params = "TEST"
        };

        Assert.NotNull(request);
        Assert.NotNull(request.Params);
    }
}
