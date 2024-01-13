using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpPost("/weatherforecast")]
[Authorize("Bearer")]
public sealed class CreateWeatherForecastEndpoint(ICreateWeatherForecastHandler handler)
    : Endpoint<CreateWeatherForecastRequestContract, WeatherForecastContract>
{
    public override async Task HandleAsync(CreateWeatherForecastRequestContract req, CancellationToken ct)
    {
        BadRequestException.ThrowIf(req.WeatherForecast is null, "WeatherForecast was not informed");

        var response = await handler.HandleAsync(req.WeatherForecast!, ct);

        await SendAsync(response!, (int)HttpStatusCode.Created, ct);
    }
}
