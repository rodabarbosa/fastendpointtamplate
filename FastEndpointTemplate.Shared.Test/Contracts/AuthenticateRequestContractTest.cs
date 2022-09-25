namespace FastEndpointTemplate.Shared.Test.Contracts;

public class AuthenticateRequestContractTest
{
    [Fact]
    public void AuthenticateRequestContract_ShouldBe_Valid()
    {
        var objectTest = new AuthenticationRequestContract
        {
            Authentication = new AuthenticationContract
            {
                Username = "Test",
                Password = "Test"
            }
        };

        Assert.NotNull(objectTest);
        Assert.NotNull(objectTest.Authentication);
        Assert.Equal("Test", objectTest.Authentication.Username);
        Assert.Equal("Test", objectTest.Authentication.Password);
    }
}
