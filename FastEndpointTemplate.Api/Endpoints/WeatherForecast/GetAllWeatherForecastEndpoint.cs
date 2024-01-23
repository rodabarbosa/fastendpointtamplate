using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpGet("/weatherforecast")]
[AllowAnonymous]
public sealed class GetAllWeatherForecastEndpoint(IGetAllWeatherForecastHandler handler)
    : Endpoint<GetAllWeatherForecastRequestContract, List<WeatherForecastContract>>
{
    async public override Task HandleAsync(GetAllWeatherForecastRequestContract requestContract, CancellationToken ct)
    {
        var response = await handler.HandleAsync(requestContract.Params!, ct);

        Response = response;
    }
}
