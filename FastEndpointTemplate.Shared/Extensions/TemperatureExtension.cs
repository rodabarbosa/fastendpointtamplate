namespace FastEndpointTemplate.Shared.Extensions;

public static class TemperatureExtension
{
    public static decimal? ToCelsius(this decimal? fahrenheit)
    {
        if (fahrenheit is null)
            return null;

        return fahrenheit.Value.ToCelsius();
    }

    public static decimal ToCelsius(this decimal fahrenheit)
    {
        return (fahrenheit - 32m) * (5m / 9m);
    }

    public static decimal? ToFahrenheit(this decimal? celsius)
    {
        if (celsius is null)
            return null;

        return celsius.Value.ToFahrenheit();
    }

    public static decimal ToFahrenheit(this decimal celsius)
    {
        return celsius * 9 / 5 + 32;
    }
}
