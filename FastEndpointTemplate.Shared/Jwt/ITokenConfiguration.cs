namespace FastEndpointTemplate.Shared.Jwt;

/// <summary>
/// The <see cref="ApiTemplate.Application.Jwt" /> namespace contains the application layer for the JWT service.
/// </summary>
public interface ITokenConfiguration
{
    /// <summary>
    /// Gets the secret key.
    /// </summary>
    string Audience { get; }

    /// <summary>
    /// Gets the issuer key.
    /// </summary>
    string Issuer { get; }

    /// <summary>
    /// Gets expiration time in seconds
    /// </summary>
    int Seconds { get; }
}
