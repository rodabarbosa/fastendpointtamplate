using FastEndpoints;
using FastEndpointTemplate.Api.Endpoints.WeatherForecast;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Api.Endpoints.Summaries;

public class GetAllWeatherForecastEndpointSummary : Summary<GetAllWeatherForecastEndpoint>
{
    public GetAllWeatherForecastEndpointSummary()
    {
        Summary = "Gets the weather forecast";
        Description = @"Method to get list of weather forecast or to query for some specific weather forecast

        For query use: field=[operationType,value]
    
        Example: date=[GreaterThan,2019-01-01]
    
        OperationType:
        Equal,
        NotEqual,
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual";
        Response<List<WeatherForecastContract>>(200, "Query result for weather forecast registered.");
        Response<ErrorContract>(400, "Bad request.");
        // Response<ErrorContract>(401, "Unauthorized.");
        // Response<ErrorContract>(403, "Forbidden.");
        // Response<ErrorContract>(404, "Not found.");
        Response<ErrorContract>(500, "Internal server error.");
    }
}
