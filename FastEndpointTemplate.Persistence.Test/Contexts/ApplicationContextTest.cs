namespace FastEndpointTemplate.Persistence.Test.Contexts;

public class ApplicationContextTest
{
    [Fact]
    public void ApplicationContext_User()
    {
        var context = ContextUtil.GetContext();

        var users = context.Users.ToList();

        Assert.NotEmpty(users);
    }

    [Fact]
    public void ApplicationContext_WeatherForecasts()
    {
        var context = ContextUtil.GetContext();

        var weatherForecasts = context.WeatherForecasts.ToList();

        Assert.NotEmpty(weatherForecasts);
    }
}
