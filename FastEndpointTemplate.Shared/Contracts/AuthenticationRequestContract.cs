using FastEndpoints;

namespace FastEndpointTemplate.Shared.Contracts;

public class AuthenticationRequestContract
{
    [FromBody] public AuthenticationContract? Authentication { get; set; }
}
