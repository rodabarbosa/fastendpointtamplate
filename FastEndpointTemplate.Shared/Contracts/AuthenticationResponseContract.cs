namespace FastEndpointTemplate.Shared.Contracts;

public class AuthenticationResponseContract
{
    public string Token { get; set; }
    public string Username { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime Expires { get; set; }
}
