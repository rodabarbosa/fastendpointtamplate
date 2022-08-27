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


    public override async Task HandleAsync(GetAllWeatherForecastRequestContract requestContract, CancellationToken ct)
    {
        var response = await _getAllWeatherForecastHandler.Handle(requestContract.Params);

        Response = response.ToList();
    }
}
