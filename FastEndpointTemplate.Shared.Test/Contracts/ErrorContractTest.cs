namespace FastEndpointTemplate.Shared.Test.Contracts;

public class ErrorContractTest
{
    [Fact]
    public void ErrorContract_Constructor()
    {
        var error = new ErrorContract();
        Assert.NotNull(error);
        Assert.Equal(0, error.Code);
        Assert.Null(error.Error);
        Assert.Null(error.Exception);
        Assert.Null(error.Exception);
        Assert.Null(error.StackTrace);
    }
}
