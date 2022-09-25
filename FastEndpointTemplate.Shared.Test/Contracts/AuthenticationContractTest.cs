namespace FastEndpointTemplate.Shared.Test.Contracts;

public class AuthenticationContractTest
{
    [Fact]
    public void AuthenticateContract_Empty()
    {
        var objectTest = new AuthenticationContract();

        Assert.NotNull(objectTest);
        Assert.Null(objectTest.Username);
        Assert.Null(objectTest.Password);
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

        Assert.NotNull(objectTest);
        Assert.Equal(text, objectTest.Username);
        Assert.Equal(text, objectTest.Password);
    }
}
