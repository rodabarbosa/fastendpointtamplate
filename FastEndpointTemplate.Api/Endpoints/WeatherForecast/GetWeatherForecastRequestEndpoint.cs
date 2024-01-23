using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpGet("/weatherforecast/{id}")]
[AllowAnonymous]
public sealed class GetWeatherForecastRequestEndpoint(IGetWeatherForecastHandler handler)
    : Endpoint<GetWeatherForecastRequestContract, WeatherForecastContract?>
{
    public override async Task HandleAsync(GetWeatherForecastRequestContract req, CancellationToken ct)
    {
        var response = await handler.HandleAsync(req.Id ?? Guid.Empty, ct);

        NotFoundException.ThrowIf(response is null, $"weather forecast with id {req.Id} not found");

        Response = response;
    }
}
