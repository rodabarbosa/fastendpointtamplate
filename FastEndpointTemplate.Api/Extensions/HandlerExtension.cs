using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Application.Handlers.Authentications;
using FastEndpointTemplate.Application.Handlers.WeatherForecasts;

namespace FastEndpointTemplate.Api.Extensions;

public static class HandlerExtension
{
    public static void AddHandlers(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationHandler, AuthenticationHandler>();
        services.AddScoped<IGetWeatherForecastHandler, GetWeatherForecastHandler>();
        services.AddScoped<IGetAllWeatherForecastHandler, GetAllWeatherForecastHandler>();
        services.AddScoped<ICreateWeatherForecastHandler, CreateWeatherForecastHandler>();
        services.AddScoped<IDeleteWeatherForecastHandler, DeleteWeatherForecastHandler>();
        services.AddScoped<IUpdateWeatherForecastHandler, UpdateWeatherForecastHandler>();
    }
}
