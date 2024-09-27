namespace FastEndpointTemplate.Shared.Test.Contracts;

public class AuthenticationContractTest
{
    [Fact]
    public void AuthenticateContract_Empty()
    {
        var objectTest = new AuthenticationContract();

        objectTest
            .Should()
            .NotBeNull();

        objectTest.Username
            .Should()
            .BeNull();

        objectTest.Password
            .Should()
            .BeNull();
    }

    [Theory]
    [InlineData("Text")]
    public void AuthenticateContract_NotEmpty(string text)
    {
        var objectTest = new AuthenticationContract
        {
            Username = text,
            Password = text
        };

        objectTest
            .Should()
            .NotBeNull();

        objectTest.Username
            .Should()
            .Be(text);

        objectTest.Password
            .Should()
            .Be(text);
    }
}
