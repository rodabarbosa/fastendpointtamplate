namespace FastEndpointTemplate.Shared.Test.Contracts;

public class GetWeatherForecastRequestContractTest
{
    [Fact]
    public void GetWeatherForecastRequest_Constructor()
    {
        var request = new GetWeatherForecastRequestContract();
        Assert.NotNull(request);
        Assert.Null(request.Id);
    }

    [Fact]
    public void GetWeatherForecastRequest_Properties()
    {
        var request = new GetWeatherForecastRequestContract
        {
            Id = Guid.NewGuid()
        };

        Assert.NotNull(request);
        Assert.NotNull(request.Id);
    }
}
