using Microsoft.IdentityModel.Tokens;

namespace FastEndpointTemplate.Shared.Jwt;

/// <summary>
/// Interface for <see cref="SigningConfiguration"/> class.
/// </summary>
public interface ISigningConfiguration
{
    /// <summary>
    /// Gets the <see cref="SecurityKey"/> that is used to sign the <see cref="JwtSecurityToken"/>.
    /// </summary>
    SecurityKey Key { get; }

    /// <summary>
    /// Gets the <see cref="SigningCredentials"/> that is used to sign the <see cref="JwtSecurityToken"/>.
    /// </summary>
    SigningCredentials SigningCredentials { get; }
}
