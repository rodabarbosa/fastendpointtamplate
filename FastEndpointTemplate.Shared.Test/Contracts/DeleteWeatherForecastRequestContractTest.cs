namespace FastEndpointTemplate.Shared.Test.Contracts;

public class DeleteWeatherForecastRequestContractTest
{
    [Fact]
    public void Delete_ShouldBeCreatedWithMessage()
    {
        var delete = new DeleteWeatherForecastRequestContract
        {
            Id = Guid.NewGuid()
        };

        Assert.NotNull(delete);
        Assert.NotNull(delete.Id);
    }
}
