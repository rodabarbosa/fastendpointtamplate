using FastEndpoints;
using FastEndpointTemplate.Application.Handlers.WeatherForecast;
using FastEndpointTemplate.Shared.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpGet("/weatherforecast")]
[AllowAnonymous]
public class GetWeatherForecestEndpoint : Endpoint<GetWeatherForecastRequestContract, List<WeatherForecastContract>>
{
    private readonly IGetWeatherForecastHandler _getWeatherForecastHandler;

    public GetWeatherForecestEndpoint(IGetWeatherForecastHandler getWeatherForecastHandler)
    {
        _getWeatherForecastHandler = getWeatherForecastHandler;
    }


    public override async Task HandleAsync(GetWeatherForecastRequestContract requestContract, CancellationToken ct)
    {
        var response = await _getWeatherForecastHandler.Handle(requestContract.Params);

        Response = response.ToList();
    }
}
