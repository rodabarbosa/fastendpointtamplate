namespace FastEndpointTemplate.Shared.Extensions;

public static class TemperatureExtension
{
    public static decimal ToCelsius(this decimal fahrenheit)
    {
        return (fahrenheit - 32m) * (5m / 9m);
    }

    public static decimal ToFahrenheit(this decimal celsius)
    {
        return celsius * 9 / 5 + 32;
    }
}
