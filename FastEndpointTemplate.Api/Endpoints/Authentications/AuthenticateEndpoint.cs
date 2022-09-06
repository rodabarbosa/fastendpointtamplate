using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using Microsoft.AspNetCore.Authorization;
using System.Net;

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
        var authentication = await _authenticationHandler.Handle(req.Authentication!);

        await SendAsync(authentication, (int)HttpStatusCode.Created, ct);
    }
}
