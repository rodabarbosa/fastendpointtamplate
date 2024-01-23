namespace FastEndpointTemplate.Shared.Contracts;

public class AuthenticationResponseContract(string token, string username, DateTime createdAt, DateTime expires)
{
    public AuthenticationResponseContract()
        : this(string.Empty, string.Empty, DateTime.Now, DateTime.MinValue)
    {
    }

    public string Token { get; set; } = token;
    public string Username { get; set; } = username;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime Expires { get; set; } = expires;
}
