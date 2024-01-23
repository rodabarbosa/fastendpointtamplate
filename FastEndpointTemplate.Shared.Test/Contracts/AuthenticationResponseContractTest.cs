namespace FastEndpointTemplate.Shared.Test.Contracts;

public class AuthenticationResponseContractTest
{
    [Fact]
    public void AuthenticateResponseContract_Empty()
    {
        var objectTest = new AuthenticationResponseContract();

        Assert.NotNull(objectTest);
        Assert.Null(objectTest.Token);
    }

    [Theory]
    [InlineData("token", "username", "2021-01-01 00:00:00", "2021-01-01 01:00:00")]
    [InlineData("", "", "2021-01-01 00:00:00", "2021-01-01 01:00:00")]
    public void AuthenticateResponseContract_NotEmpty(string token, string username, DateTime createdAt, DateTime expires)
    {
        var objectTest = new AuthenticationResponseContract
        {
            Token = token,
            Expires = expires,
            Username = username,
            CreatedAt = createdAt
        };

        Assert.NotNull(objectTest);
        Assert.Equal(token, objectTest.Token);
        Assert.Equal(expires, objectTest.Expires);
        Assert.Equal(username, objectTest.Username);
        Assert.Equal(createdAt, objectTest.CreatedAt);
    }
}
