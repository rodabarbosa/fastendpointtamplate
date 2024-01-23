namespace FastEndpointTemplate.Shared.Contracts;

public class AuthenticationContract(string? username, string? password)
{
    public AuthenticationContract()
        : this(default, default)
    {
    }

    public string? Username { get; set; } = username;
    public string? Password { get; set; } = password;
}
