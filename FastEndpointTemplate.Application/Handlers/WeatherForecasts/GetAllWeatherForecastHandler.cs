using FastEndpointTemplate.Domain.Entities;
using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Enumerators;
using FastEndpointTemplate.Shared.Extensions;
using FastEndpointTemplate.Shared.Models;

namespace FastEndpointTemplate.Application.Handlers.WeatherForecasts;

public class GetAllWeatherForecastHandler : IGetAllWeatherForecastHandler
{
    private readonly IWeatherForecastRepository _weatherForecastRepository;

    public GetAllWeatherForecastHandler(IWeatherForecastRepository weatherForecastRepository)
    {
        _weatherForecastRepository = weatherForecastRepository;
    }

    public async Task<IEnumerable<WeatherForecastContract>?> HandleAsync(string? param)
    {
        var weathers = _weatherForecastRepository.Get();

        weathers = FilterByDate(weathers, param);

        weathers = FilterByTemperatureCelsius(weathers, param);

        weathers = FilterByTemperatureFahrenheit(weathers, param);

        return weathers?.Select(x => new WeatherForecastContract
            {
                Id = x.Id,
                Date = x.Date,
                TemperatureCelsius = x.TemperatureCelsius,
                Summary = x.Summary
            })
            .ToList();
    }

    private static IQueryable<WeatherForecast>? FilterByDate(IQueryable<WeatherForecast>? weathers, string param)
    {
        var filter = ExtractDateParam(param);

        return filter?.Operation switch
        {
            Operation.GreaterThan => weathers?.Where(w => w.Date > filter.Value),
            Operation.LessThan => weathers?.Where(w => w.Date < filter.Value),
            Operation.Equal => weathers?.Where(w => w.Date == filter.Value),
            Operation.NotEqual => weathers?.Where(w => w.Date != filter.Value),
            Operation.GreaterThanOrEqual => weathers?.Where(w => w.Date >= filter.Value),
            Operation.LessThanOrEqual => weathers?.Where(w => w.Date <= filter.Value),
            _ => weathers
        };
    }

    private static OperationParam<DateTime>? ExtractDateParam(string param)
    {
        if (string.IsNullOrEmpty(param))
            return default;

        var values = param.Split('&');
        foreach (var item in values)
        {
            if (!item.ToLower().StartsWith("date="))
                continue;

            var date = item.Split('=');
            var operationParam = CleanParam(date[1]).Split(',');
            var operation = operationParam[0].ToOperation();
            var dateTime = operationParam[1].ToDateTime();

            return new OperationParam<DateTime>
            {
                Value = dateTime,
                Operation = operation
            };
        }

        return default;
    }

    private static IQueryable<WeatherForecast>? FilterByTemperatureCelsius(IQueryable<WeatherForecast>? weathers, string param)
    {
        var filter = ExtractTemperatureCelsiusParam(param);

        return filter?.Operation switch
        {
            Operation.GreaterThan => weathers?.Where(w => w.TemperatureCelsius > filter.Value),
            Operation.LessThan => weathers?.Where(w => w.TemperatureCelsius < filter.Value),
            Operation.Equal => weathers?.Where(w => w.TemperatureCelsius == filter.Value),
            Operation.NotEqual => weathers?.Where(w => w.TemperatureCelsius != filter.Value),
            Operation.GreaterThanOrEqual => weathers?.Where(w => w.TemperatureCelsius >= filter.Value),
            Operation.LessThanOrEqual => weathers?.Where(w => w.TemperatureCelsius <= filter.Value),
            _ => weathers
        };
    }

    private static OperationParam<decimal>? ExtractTemperatureCelsiusParam(string param)
    {
        return GetTemperature(param, "temperatureCelsius");
    }

    private static IQueryable<WeatherForecast>? FilterByTemperatureFahrenheit(IQueryable<WeatherForecast>? weathers, string param)
    {
        var filter = ExtractTemperatureFahrenheitParam(param);

        return filter?.Operation switch
        {
            Operation.GreaterThan => weathers?.Where(w => w.TemperatureCelsius.ToFahrenheit() > filter.Value),
            Operation.LessThan => weathers?.Where(w => w.TemperatureCelsius.ToFahrenheit() < filter.Value),
            Operation.Equal => weathers?.Where(w => w.TemperatureCelsius.ToFahrenheit() == filter.Value),
            Operation.NotEqual => weathers?.Where(w => w.TemperatureCelsius.ToFahrenheit() != filter.Value),
            Operation.GreaterThanOrEqual => weathers?.Where(w => w.TemperatureCelsius.ToFahrenheit() >= filter.Value),
            Operation.LessThanOrEqual => weathers?.Where(w => w.TemperatureCelsius.ToFahrenheit() <= filter.Value),
            _ => weathers
        };
    }

    private static OperationParam<decimal>? ExtractTemperatureFahrenheitParam(string param)
    {
        return GetTemperature(param, "temperatureFahrenheit");
    }

    private static OperationParam<decimal>? GetTemperature(string param, string key)
    {
        var lowercaseKey = key.ToLower();
        if (string.IsNullOrEmpty(param))
            return default;

        var values = param.Split('&');
        foreach (var item in values)
        {
            if (!item.ToLower().StartsWith($"{lowercaseKey}="))
                continue;

            var data = item.Split('=');
            var operationParam = CleanParam(data[1]).Split(',');
            var operation = operationParam[0].ToOperation();

            _ = decimal.TryParse(operationParam[1], out var value);

            return new OperationParam<decimal>
            {
                Value = value,
                Operation = operation
            };
        }

        return default;
    }

    private static string CleanParam(string param)
    {
        return param.TrimStart('[')
            .TrimEnd(']');
    }
}
