using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpDelete("/weatherforecast/{id}")]
[Authorize("Bearer")]
public class DeleteWeatherForecastEndpoint : Endpoint<DeleteWeatherForecastRequestContract, DeleteResponseContract>
{
    private readonly IDeleteWeatherForecastHandler _handler;

    public DeleteWeatherForecastEndpoint(IDeleteWeatherForecastHandler handler)
    {
        _handler = handler;
    }

    public override async Task HandleAsync(DeleteWeatherForecastRequestContract req, CancellationToken ct)
    {
        await _handler.Handle(req.Id ?? Guid.Empty);

        var response = new DeleteResponseContract { Success = true };

        await SendAsync(response, (int)HttpStatusCode.NoContent, ct);
    }
}
