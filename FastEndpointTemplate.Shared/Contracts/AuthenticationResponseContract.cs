namespace FastEndpointTemplate.Shared.Contracts;

public class AuthenticationResponseContract
{
    public bool Authenticated { get; set; }
    public string Token { get; set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime Expires { get; set; }
}
