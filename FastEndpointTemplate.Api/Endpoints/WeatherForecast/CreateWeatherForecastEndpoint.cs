using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpPost("/weatherforecast")]
[Authorize("Bearer")]
public class CreateWeatherForecastEndpoint : Endpoint<CreateWeatherForecastRequestContract, WeatherForecastContract>
{
    private readonly ICreateWeatherForecastHandler _handler;

    public CreateWeatherForecastEndpoint(ICreateWeatherForecastHandler handler)
    {
        _handler = handler;
    }

    public override async Task HandleAsync(CreateWeatherForecastRequestContract req, CancellationToken ct)
    {
        BadRequestException.ThrowIf(req.WeatherForecast is null, "WeatherForecast was not informed");

        var response = await _handler.Handle(req.WeatherForecast);

        Response = response;
    }
}
