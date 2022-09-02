using FastEndpoints;
using FastEndpointTemplate.Api.Endpoints.WeatherForecast;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Api.Endpoints.Summaries;

public class CreateWeatherForecastEndpointSummary : Summary<CreateWeatherForecastEndpoint>
{
    public CreateWeatherForecastEndpointSummary()
    {
        Summary = "Create a weather forecast";
        Description = @"Method to create weather forecast";
        Response<WeatherForecastContract>(201, "Weather forecast created.");
        Response<ErrorContract>(400, "Bad request.");
        Response<ErrorContract>(500, "Internal server error.");
    }
}
