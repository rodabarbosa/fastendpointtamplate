using FastEndpointTemplate.Api.Models;

namespace FastEndpointTemplate.Api.Test.Extensions;

public class SwaggerExtensionTest
{
    [Fact]
    public void AddService()
    {
        var builder = WebApplication.CreateBuilder();
        var serviceCollection = builder.Services;

        var apiInfo = new ApiInfo
        {
            Title = "Test",
            Description = "Test",
            Version = "V0.1"
        };


        serviceCollection.AddSwagger(apiInfo);

        var app = builder.Build();
        app.UseSwaggerDoc();

        Assert.True(true);
    }
}
