namespace FastEndpointTemplate.Domain.Entities;

public class WeatherForecast
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public decimal TemperatureCelsius { get; set; }
    public string? Summary { get; set; }
}
