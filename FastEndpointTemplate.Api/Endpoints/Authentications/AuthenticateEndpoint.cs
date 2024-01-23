using FastEndpoints;
using FastEndpointTemplate.Application.Handlers;
using FastEndpointTemplate.Shared.Contracts;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace FastEndpointTemplate.Api.Endpoints.Authentications;

[HttpPost("/authenticate")]
[AllowAnonymous]
public class AuthenticateEndpoint(IAuthenticationHandler handler)
    : Endpoint<AuthenticationRequestContract, AuthenticationResponseContract>
{
    public override async Task HandleAsync(AuthenticationRequestContract req, CancellationToken ct)
    {
        var response = await handler.HandleAsync(req.Authentication!, ct);

        await SendAsync(response, (int)HttpStatusCode.Created, ct);
    }
}
