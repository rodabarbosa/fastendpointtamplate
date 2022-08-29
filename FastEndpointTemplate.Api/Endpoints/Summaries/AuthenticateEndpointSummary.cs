using FastEndpoints;
using FastEndpointTemplate.Api.Endpoints.Authentications;
using FastEndpointTemplate.Shared.Contracts;

namespace FastEndpointTemplate.Api.Endpoints.Summaries;

public class AuthenticateEndpointSummary : Summary<AuthenticateEndpoint>
{
    public AuthenticateEndpointSummary()
    {
        Summary = "Authenticate user";
        Description = "Authenticate user";
        Response<AuthenticationResponseContract>(200, "Authenticated");
        Response<ErrorContract>(400, "Bad request.");
        Response<ErrorContract>(500, "Internal server error.");
    }
}
