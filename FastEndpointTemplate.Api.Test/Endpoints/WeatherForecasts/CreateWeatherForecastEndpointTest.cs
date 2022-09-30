namespace FastEndpointTemplate.Api.Test.Endpoints.WeatherForecasts;

public class CreateWeatherForecastEndpointTest : BaseEndpointTest
{
    [Fact]
    public async Task Create_Invalid()
    {
        var di = AppBuilder.ApplicationServices.GetRequiredService<ICreateWeatherForecastHandler>();

        var resource = new CreateWeatherForecastEndpoint(di);

        var request = new CreateWeatherForecastRequestContract
        {
            WeatherForecast = new WeatherForecastContract
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                TemperatureCelsius = 0,
                TemperatureFahrenheit = 32,
                Summary = "teste"
            }
        };

        await Assert.ThrowsAsync<Exception>(() => resource.HandleAsync(request, new CancellationToken(true)));
    }
}
