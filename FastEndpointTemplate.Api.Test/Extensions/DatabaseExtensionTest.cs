namespace FastEndpointTemplate.Api.Test.Extensions;

public class DatabaseExtensionTest
{
    [Fact]
    public void Database_Test()
    {
        var builder = WebApplication.CreateBuilder();
        var serviceCollection = builder.Services;

        var action = () => serviceCollection.AddDatabase("test");

        action.Should()
            .NotThrow();
    }

    [Fact]
    public void GetOptionBuilder()
    {
        var action = () =>
        {
            var builder = WebApplication.CreateBuilder();
            var serviceCollection = builder.Services;

            serviceCollection.AddDatabase("test");

            _ = builder.Build();
        };

        action.Should()
            .NotThrow();
    }
}
