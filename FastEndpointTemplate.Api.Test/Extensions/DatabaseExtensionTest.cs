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

        Assert.True(true);
    }

    [Fact]
    public void GetOptionBuilder()
    {
        var builder = WebApplication.CreateBuilder();
        var serviceCollection = builder.Services;

        serviceCollection.AddDatabase("test");

        var app = builder.Build();

        var context = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<ApplicationContext>();

        Assert.NotNull(context);
    }
}
