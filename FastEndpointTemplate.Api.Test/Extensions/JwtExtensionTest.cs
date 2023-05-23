using FastEndpointTemplate.Shared.Models;

namespace FastEndpointTemplate.Api.Test.Extensions;

public class JwtExtensionTest
{
    private readonly IServiceCollection _serviceCollection;

    public JwtExtensionTest()
    {
        var builder = WebApplication.CreateBuilder();
        _serviceCollection = builder.Services;
    }

    [Fact]
    public void Test()
    {
        var tokenConfigurations = new TokenConfiguration
        {
            Audience = "test",
            Issuer = "test",
            Seconds = 20
        };

        _serviceCollection.AddJwtService(tokenConfigurations);

        Assert.True(true);
    }
}
