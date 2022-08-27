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
        Response<WeatherForecastContract>(200, "Weather forecast created.");
        Response<ErrorContract>(400, "Bad request.");
        // Response<ErrorContract>(401, "Unauthorized.");
        // Response<ErrorContract>(403, "Forbidden.");
        // Response<ErrorContract>(404, "Not found.");
        Response<ErrorContract>(500, "Internal server error.");
    }
}
