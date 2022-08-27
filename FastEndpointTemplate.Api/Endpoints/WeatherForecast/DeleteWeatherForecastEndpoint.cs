using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpDelete("/weatherforecast/{id}")]
[AllowAnonymous]
public class DeleteWeatherForecastEndpoint : Endpoint<DeleteWeatherForecastRequestContract, DeleteResponseContract>
{
    private readonly IDeleteWeatherForecastHandler _handler;

    public DeleteWeatherForecastEndpoint(IDeleteWeatherForecastHandler handler)
    {
        _handler = handler;
    }

    public override async Task HandleAsync(DeleteWeatherForecastRequestContract req, CancellationToken ct)
    {
        BadRequestException.ThrowIf(req.Id is null, "weather forecast id not informed");

        await _handler.Handle(req.Id ?? Guid.Empty);

        Response = new DeleteResponseContract { Success = true };
    }
}
