using FastEndpoints;

namespace FastEndpointTemplate.Api.Test.Endpoints;

public abstract class BaseEndpointTest
{
    protected readonly IApplicationBuilder AppBuilder;

    protected BaseEndpointTest()
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddResponseCompression();
        var configuration = builder.Configuration;
        builder.Services.AddJwtService(configuration);
        builder.Services.AddDatabase("Template");
        builder.Services.AddAuthorization();
        builder.Services.AddFastEndpoints();
        builder.Services.AddSwagger();

        AppBuilder = builder.Build();
    }
}
