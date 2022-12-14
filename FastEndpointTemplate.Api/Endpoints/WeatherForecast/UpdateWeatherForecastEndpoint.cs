using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpPut("/weatherforecast/{id}")]
[Authorize("Bearer")]
public class UpdateWeatherForecastEndpoint : Endpoint<UpdateWeatherForecastRequestContract, WeatherForecastContract>
{
    private readonly IUpdateWeatherForecastHandler _handler;

    public UpdateWeatherForecastEndpoint(IUpdateWeatherForecastHandler handler)
    {
        _handler = handler;
    }

    public override async Task HandleAsync(UpdateWeatherForecastRequestContract req, CancellationToken ct)
    {
        BadRequestException.ThrowIf(req.Id is null, "weather forecast id not informed");
        BadRequestException.ThrowIf(req.WeatherForecast is null, "weather forecast not informed");

        var response = await _handler.HandleAsync(req.Id ?? Guid.Empty, req.WeatherForecast!);

        await SendAsync(response, (int)HttpStatusCode.NoContent, ct);
    }
}
