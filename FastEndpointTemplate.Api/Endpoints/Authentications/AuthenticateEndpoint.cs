using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace FastEndpointTemplate.Api.Endpoints.Authentications;

[HttpPost("/authenticate")]
[AllowAnonymous]
public class AuthenticateEndpoint : Endpoint<AuthenticationRequestContract, AuthenticationResponseContract>
{
    private readonly IAuthenticationHandler _authenticationHandler;

    public AuthenticateEndpoint(IAuthenticationHandler authenticationHandler)
    {
        _authenticationHandler = authenticationHandler;
    }

    public override async Task HandleAsync(AuthenticationRequestContract req, CancellationToken ct)
    {
        Response = await _authenticationHandler.Handle(req.Authentication);
    }
}
