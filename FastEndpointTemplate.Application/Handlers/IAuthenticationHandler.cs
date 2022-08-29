using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Application.Handlers;

public interface IAuthenticationHandler
{
    Task<AuthenticationResponseContract> Handle(AuthenticationContract contract);
}
