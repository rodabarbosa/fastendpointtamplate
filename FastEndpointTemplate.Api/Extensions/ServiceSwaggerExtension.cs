using FastEndpoints.Swagger;

namespace FastEndpointTemplate.Api.Extensions;

public static class ServiceSwaggerExtension
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
        app.UseOpenApi(); //add this
        app.UseSwaggerUi3(s => s.ConfigureDefaults()); //add this
    }
}
