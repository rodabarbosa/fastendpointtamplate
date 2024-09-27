namespace FastEndpointTemplate.Shared.Test.Contracts;

public class ErrorContractTest
{
    [Fact]
    public void ErrorContract_Constructor()
    {
        var error = new ErrorContract();

        error.Code
            .Should()
            .Be(400);

        error.Error
            .Should()
            .BeNull();

        error.Exception
            .Should()
            .BeNull();

        error.StackTrace
            .Should()
            .BeNull();
    }
}
