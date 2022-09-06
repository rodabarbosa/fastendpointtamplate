using FastEndpoints;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Api.Validators;

public class AuthenticationRequestValidator : Validator<AuthenticationRequestContract>
{
    public AuthenticationRequestValidator()
    {
        RuleFor(x => x.Authentication)
            .NotNull()
            .NotEqual(new AuthenticationContract());

        RuleFor(x => x.Authentication!.Username)
            .NotEmpty();

        RuleFor(x => x.Authentication!.Password)
            .NotEmpty();
    }
}
