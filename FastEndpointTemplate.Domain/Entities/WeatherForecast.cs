namespace FastEndpointTemplate.Domain.Entities;

public class WeatherForecast
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public double TemperatureCelsius { get; set; }
    public string Summary { get; set; }
}