using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpGet("/weatherforecast/{id}")]
[AllowAnonymous]
public class GetWeatherForecastRequestEndpoint : Endpoint<GetWeatherForecastRequestContract, WeatherForecastContract?>
{
    private readonly IGetWeatherForecastHandler _getWeatherForecastHandler;

    public GetWeatherForecastRequestEndpoint(IGetWeatherForecastHandler getWeatherForecastHandler)
    {
        _getWeatherForecastHandler = getWeatherForecastHandler;
    }

    public override async Task HandleAsync(GetWeatherForecastRequestContract req, CancellationToken ct)
    {
        var response = await _getWeatherForecastHandler.HandleAsync(req.Id ?? Guid.Empty);

        NotFoundException.ThrowIf(response is null, $"weather forecast with id {req.Id} not found");

        Response = response;
    }
}
