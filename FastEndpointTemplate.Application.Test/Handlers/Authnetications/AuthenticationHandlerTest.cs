using FastEndpointTemplate.Shared.Exceptions;

namespace FastEndpointTemplate.Application.Test.Handlers.Authnetications;

public class AuthenticationHandlerTest
{
    [Theory]
    [InlineData("test", "test", false)]
    [InlineData(null, "", false)]
    [InlineData("admin", "admin@123", true)]
    public async Task Handle_GivenValidRequest_ShouldReturnSuccess(string? username, string? password, bool expected)
    {
        // Arrange
        var context = ContextUtil.GetContext();
        var userRepository = new UserRepository(context);
        var signingConfiguration = new SigningConfiguration();
        var tokenConfiguration = new TokenConfiguration();

        var handler = new AuthenticationHandler(userRepository, signingConfiguration, tokenConfiguration);

        var contract = new AuthenticationContract
        {
            Username = username,
            Password = password
        };

        if (expected)
        {
            var result = await handler.HandleAsync(contract, CancellationToken.None);
            Assert.NotNull(result);
        }
        else
            await Assert.ThrowsAsync<BadRequestException>(() => handler.HandleAsync(contract, CancellationToken.None));
    }
}
