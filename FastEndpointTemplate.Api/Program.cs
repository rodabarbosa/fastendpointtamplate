using FastEndpoints;
using FastEndpoints.Swagger;
using FastEndpointTemplate.Application.Handlers.WeatherForecast;
using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Persistence.Contexts;
using FastEndpointTemplate.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(o => o.UseInMemoryDatabase("Template"));
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
builder.Services.AddScoped<IGetWeatherForecastHandler, GetWeatherForecastHandler>();

builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc(settings =>
{
    settings.Title = "FastEnpoint Template";
    settings.Version = "v1";
});

var app = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();
app.UseOpenApi(); //add this
app.UseSwaggerUi3(s => s.ConfigureDefaults()); //add this

app.Run();
