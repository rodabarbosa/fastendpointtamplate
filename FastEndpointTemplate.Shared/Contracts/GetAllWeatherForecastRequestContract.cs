namespace FastEndpointTemplate.Shared.Contracts;

public class GetAllWeatherForecastRequestContract(string? @params)
{
    public GetAllWeatherForecastRequestContract()
        : this(default)
    {
    }

    public string? Params { get; set; } = @params;
}
