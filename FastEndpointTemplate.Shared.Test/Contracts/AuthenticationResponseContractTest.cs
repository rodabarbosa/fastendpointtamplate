namespace FastEndpointTemplate.Shared.Test.Contracts;

public class AuthenticationResponseContractTest
{
    [Fact]
    public void AuthenticateResponseContract_Empty()
    {
        var objectTest = new AuthenticationResponseContract();

        objectTest
            .Should()
            .NotBeNull();

        objectTest.Token
            .Should()
            .BeEmpty();
    }

    [Theory]
    [InlineData("token", "username", "2021-01-01T00:00:00", "2021-01-01T01:00:00")]
    [InlineData("", "", "2021-01-01T00:00:00", "2021-01-01T01:00:00")]
    public void AuthenticateResponseContract_NotEmpty(string token, string username, DateTime createdAt, DateTime expires)
    {
        var objectTest = new AuthenticationResponseContract
        {
            Token = token,
            Expires = expires,
            Username = username,
            CreatedAt = createdAt
        };

        objectTest
            .Should()
            .NotBeNull();

        objectTest.Token
            .Should()
            .Be(token);

        objectTest.Expires
            .Should()
            .Be(expires);

        objectTest.Username
            .Should()
            .Be(username);

        objectTest.CreatedAt
            .Should()
            .Be(createdAt);
    }
}
