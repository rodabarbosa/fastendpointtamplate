using FastEndpoints.Swagger;
using FastEndpointTemplate.Api.Models;

namespace FastEndpointTemplate.Api.Extensions;

static public class SwaggerExtension
{
    static public void AddSwagger(this IServiceCollection services, ApiInfo info)
    {
        services.SwaggerDocument(options =>
        {
            options.DocumentSettings = settings =>
            {
                settings.Title = info?.Title;
                settings.Description = info?.Description;
                settings.Version = info?.Version;
            };
        });
    }

    static public void UseSwaggerDoc(this IApplicationBuilder app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi3(s => s.ConfigureDefaults());
    }
}
