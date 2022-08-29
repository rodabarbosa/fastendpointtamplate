using FastEndpoints.Swagger;

namespace FastEndpointTemplate.Api.Extensions;

public static class SwaggerExtension
{
    public static void AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerDoc(settings =>
        {
            settings.Title = "FastEnpoint Template";
            settings.Version = "v1";
        });
    }

    public static void UseSwaggerDoc(this IApplicationBuilder app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi3(s => s.ConfigureDefaults());
    }
}
