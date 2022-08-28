using FastEndpoints;
using FastEndpointTemplate.Api.Endpoints.WeatherForecast;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Api.Endpoints.Summaries;

public class UpdateWeatherForecastEndpointSummary : Summary<UpdateWeatherForecastEndpoint>
{
    public UpdateWeatherForecastEndpointSummary()
    {
        Summary = "Update a weather forecast";
        Description = @"Method to Update weather forecast";
        Response<WeatherForecastContract>(200, "Weather forecast updated.");
        Response<ErrorContract>(400, "Bad request.");
        Response<ErrorContract>(500, "Internal server error.");
    }
}
