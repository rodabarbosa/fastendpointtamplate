namespace FastEndpointTemplate.Shared.Extensions;

public static class TemperatureExtension
{
    public static double ToCelsius(this double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }


    public static double ToFahrenheit(this double celsius)
    {
        return celsius * 9 / 5 + 32;
    }
}