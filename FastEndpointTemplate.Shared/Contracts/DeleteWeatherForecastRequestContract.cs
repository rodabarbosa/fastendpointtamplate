namespace FastEndpointTemplate.Shared.Contracts;

public class DeleteWeatherForecastRequestContract(Guid? id)
{
    public DeleteWeatherForecastRequestContract()
        : this(default)
    {
    }

    public Guid? Id { get; set; } = id;
}
