using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpDelete("/weatherforecast/{id}")]
[Authorize("Bearer")]
public sealed class DeleteWeatherForecastEndpoint(IDeleteWeatherForecastHandler handler)
    : Endpoint<DeleteWeatherForecastRequestContract, DeleteResponseContract>
{
    public override async Task HandleAsync(DeleteWeatherForecastRequestContract req, CancellationToken ct)
    {
        await handler.HandleAsync(req.Id ?? Guid.Empty, ct);

        var response = new DeleteResponseContract { Success = true };

        await SendAsync(response, (int)HttpStatusCode.NoContent, ct);
    }
}
