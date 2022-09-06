using FastEndpoints;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Api.Validators;

public class CreateWeatherForecastRequestValidator : Validator<CreateWeatherForecastRequestContract>
{
    public CreateWeatherForecastRequestValidator()
    {
        RuleFor(x => x.WeatherForecast)
            .NotNull()
            .NotEqual(new WeatherForecastContract());

        RuleFor(x => x.WeatherForecast!.Date)
            .NotEmpty()
            .NotEqual(DateTime.MinValue)
            .LessThanOrEqualTo(DateTime.Now);

        RuleFor(x => x.WeatherForecast!.TemperatureCelsius)
            .NotNull()
            .GreaterThanOrEqualTo(-5000)
            .LessThanOrEqualTo(5000);
    }
}
