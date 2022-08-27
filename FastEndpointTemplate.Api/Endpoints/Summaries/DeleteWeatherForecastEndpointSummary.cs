using FastEndpoints;
using FastEndpointTemplate.Api.Endpoints.WeatherForecast;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Api.Endpoints.Summaries;

public class DeleteWeatherForecastEndpointSummary : Summary<DeleteWeatherForecastEndpoint>
{
    public DeleteWeatherForecastEndpointSummary()
    {
        Summary = "Delete a weather forecast";
        Description = @"Method to delete weather forecast";
        Response<DeleteResponseContract>(200, "Weather forecast Deleted.");
        Response<ErrorContract>(400, "Bad request.");
        // Response<ErrorContract>(401, "Unauthorized.");
        // Response<ErrorContract>(403, "Forbidden.");
        // Response<ErrorContract>(404, "Not found.");
        Response<ErrorContract>(500, "Internal server error.");
    }
}
