using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpPut("/weatherforecast/{id}")]
[Authorize("Bearer")]
public sealed class UpdateWeatherForecastEndpoint(IUpdateWeatherForecastHandler handler)
    : Endpoint<UpdateWeatherForecastRequestContract, WeatherForecastContract>
{
    public override async Task HandleAsync(UpdateWeatherForecastRequestContract req, CancellationToken ct)
    {
        BadRequestException.ThrowIf(req.Id is null, "weather forecast id not informed");
        BadRequestException.ThrowIf(req.WeatherForecast is null, "weather forecast not informed");

        var response = await handler.HandleAsync(req.Id ?? Guid.Empty, req.WeatherForecast!, ct);

        await SendAsync(response, (int)HttpStatusCode.NoContent, ct);
    }
}
