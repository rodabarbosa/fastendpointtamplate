namespace FastEndpointTemplate.Shared.Contracts;

public class GetWeatherForecastRequestContract(Guid? id)
{
    public GetWeatherForecastRequestContract()
        : this(default)
    {
    }

    public Guid? Id { get; set; } = id;
}
