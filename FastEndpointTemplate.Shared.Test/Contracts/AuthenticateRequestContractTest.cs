namespace FastEndpointTemplate.Shared.Test.Contracts;

public class AuthenticateRequestContractTest
{
    [Theory]
    [InlineData("Test")]
    public void AuthenticateRequestContract_ShouldBe_Valid(string value)
    {
        var objectTest = new AuthenticationRequestContract
        {
            Authentication = new AuthenticationContract
            {
                Username = value,
                Password = value
            }
        };

        objectTest
            .Should()
            .NotBeNull();

        objectTest.Authentication
            .Should()
            .NotBeNull();

        objectTest.Authentication
            .Username
            .Should()
            .Be(value);

        objectTest.Authentication
            .Password
            .Should()
            .Be(value);
    }
}
