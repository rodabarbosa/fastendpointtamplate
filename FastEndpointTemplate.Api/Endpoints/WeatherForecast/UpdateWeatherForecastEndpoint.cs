using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpPut("/weatherforecast/{id}")]
[AllowAnonymous]
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

        var response = await _handler.Handle(req.Id ?? Guid.Empty, req.WeatherForecast);

        Response = response;
    }
}
