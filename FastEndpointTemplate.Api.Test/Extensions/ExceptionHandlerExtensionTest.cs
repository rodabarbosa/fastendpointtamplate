namespace FastEndpointTemplate.Api.Test.Extensions;

public class ExceptionHandlerExtensionTest
{
    private readonly WebApplication _app;

    public ExceptionHandlerExtensionTest()
    {
        var builder = WebApplication.CreateBuilder();

        _app = builder.Build();
    }

    [Fact]
    public void ExceptionHandler_Test()
    {
        _app.UseCustomExceptionHandler();
    }
}
