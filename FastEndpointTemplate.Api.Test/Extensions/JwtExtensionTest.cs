using Microsoft.Extensions.Configuration;

namespace FastEndpointTemplate.Api.Test.Extensions;

public class JwtExtensionTest
{
    private readonly ConfigurationManager _configuration;
    private readonly IServiceCollection _serviceCollection;

    public JwtExtensionTest()
    {
        var builder = WebApplication.CreateBuilder();
        _serviceCollection = builder.Services;
        _configuration = builder.Configuration;
    }

    [Fact]
    public void Test()
    {
        _serviceCollection.AddJwtService(_configuration);
    }
}
