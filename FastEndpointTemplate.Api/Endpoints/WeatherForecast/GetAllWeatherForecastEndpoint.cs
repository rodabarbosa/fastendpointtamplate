using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTemplate.Api.Endpoints.WeatherForecast;

[HttpGet("/weatherforecast")]
[AllowAnonymous]
public class GetAllWeatherForecastEndpoint : Endpoint<GetAllWeatherForecastRequestContract, List<WeatherForecastContract>>
{
    private readonly IGetAllWeatherForecastHandler _getAllWeatherForecastHandler;

    public GetAllWeatherForecastEndpoint(IGetAllWeatherForecastHandler getAllWeatherForecastHandler)
    {
        _getAllWeatherForecastHandler = getAllWeatherForecastHandler;
    }

    async public override Task HandleAsync(GetAllWeatherForecastRequestContract requestContract, CancellationToken ct)
    {
        var response = await _getAllWeatherForecastHandler.HandleAsync(requestContract.Params!)
            .ConfigureAwait(false);

        Response = response.ToList();
    }
}
