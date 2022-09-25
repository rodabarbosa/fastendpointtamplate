namespace FastEndpointTemplate.Domain.Entities;

public sealed class WeatherForecast
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Date { get; set; } = DateTime.Now;
    public decimal TemperatureCelsius { get; set; }
    public string? Summary { get; set; }
}
