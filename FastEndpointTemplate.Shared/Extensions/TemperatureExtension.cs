namespace FastEndpointTemplate.Shared.Extensions;

public static class TemperatureExtension
{
    public static decimal? ToCelsius(this decimal? fahrenheit, int decimalHolders = 1)
    {
        if (!fahrenheit.HasValue)
            return default;

        return fahrenheit.Value.ToCelsius(decimalHolders);
    }

    public static decimal ToCelsius(this decimal fahrenheit, int decimalHolders = 1)
    {
        var celsius = (fahrenheit - 32m) * (5m / 9m);
        return decimal.Round(celsius, decimalHolders);
    }

    public static decimal? ToFahrenheit(this decimal? celsius, int decimalHolders = 1)
    {
        if (!celsius.HasValue)
            return default;

        return celsius.Value.ToFahrenheit(decimalHolders);
    }

    public static decimal ToFahrenheit(this decimal celsius, int decimalHolders = 1)
    {
        var fahrenheit = celsius * 9 / 5 + 32;
        return decimal.Round(fahrenheit, decimalHolders);
    }
}
