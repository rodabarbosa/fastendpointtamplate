namespace FastEndpointTemplate.Api.Test.Extensions;

public class SwaggerExtensionTest
{
    [Fact]
    public void AddService()
    {
        var builder = WebApplication.CreateBuilder();
        var serviceCollection = builder.Services;
        var configuration = builder.Configuration;
        serviceCollection.AddJwtService(configuration);

        var app = builder.Build();
        app.UseSwaggerDoc();

        Assert.True(true);
    }
}
