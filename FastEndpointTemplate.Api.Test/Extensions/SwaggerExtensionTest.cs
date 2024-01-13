using FastEndpointTemplate.Api.Models;

namespace FastEndpointTemplate.Api.Test.Extensions;

public class SwaggerExtensionTest
{
    [Fact]
    public void AddService()
    {
        var action = () =>
        {
            var apiInfo = new ApiInfo
            {
                Title = "Test",
                Description = "Test",
                Version = "V0.1"
            };

            var builder = WebApplication.CreateBuilder();
            builder.Services.AddSwagger(apiInfo);
        };

        action.Should()
            .NotThrow();
    }
}
