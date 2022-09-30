using FastEndpointTemplate.Persistence.Contexts;

namespace FastEndpointTemplate.Api.Test.Extensions;

public class DatabaseExtensionTest
{
    [Fact]
    public void Database_Test()
    {
        var builder = WebApplication.CreateBuilder();
        var serviceCollection = builder.Services;

        serviceCollection.AddDatabase("test");
    }

    [Fact]
    public void GetOptionBuilder()
    {
        var builder = WebApplication.CreateBuilder();
        var serviceCollection = builder.Services;

        serviceCollection.AddDatabase("test");

        var app = builder.Build();

        ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<ApplicationContext>();
    }
}
