using FastEndpoints;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Api.Validators;

public class DeleteWeatherForecastRequestValidator : Validator<DeleteWeatherForecastRequestContract>
{
    public DeleteWeatherForecastRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}
