using FastEndpoints;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Api.Validators;

public class UpdateWeatherForecastRequestValidator : Validator<UpdateWeatherForecastRequestContract>
{
    public UpdateWeatherForecastRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);

        RuleFor(x => x.WeatherForecast)
            .NotNull()
            .NotEqual(new WeatherForecastContract());

        RuleFor(x => x.WeatherForecast.Date)
            .NotEmpty()
            .GreaterThan(DateTime.MinValue)
            .LessThanOrEqualTo(DateTime.Now);

        RuleFor(x => x.WeatherForecast.TemperatureCelsius)
            .NotNull()
            .GreaterThanOrEqualTo(-5000)
            .LessThanOrEqualTo(5000);
    }
}
