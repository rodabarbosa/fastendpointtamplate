using FastEndpoints;
using FastEndpointTemplate.Api.Endpoints.WeatherForecast;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Api.Endpoints.Summaries;

public class GetWeatherForecastEndpointSummary : Summary<GetWeatherForecastRequestEndpoint>
{
    public GetWeatherForecastEndpointSummary()
    {
        Summary = "Gets the weather forecast";
        Description = @"Method to get weather forecast by id";
        Response<WeatherForecastContract>(200, "Weather forecast found.");
        Response<ErrorContract>(400, "Bad request.");
        Response<ErrorContract>(500, "Internal server error.");
    }
}
