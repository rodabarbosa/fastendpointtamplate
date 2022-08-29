using FastEndpointTemplate.Shared.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace FastEndpointTemplate.Shared.Models;

/// <inheritdoc />
public sealed class SigningConfiguration : ISigningConfiguration
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SigningConfiguration"/> class.
    /// </summary>
    public SigningConfiguration()
    {
        using var provider = new RSACryptoServiceProvider(2048);

        Key = new RsaSecurityKey(provider.ExportParameters(true));

        SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
    }

    /// <inheritdoc />
    public SecurityKey Key { get; }

    /// <inheritdoc />
    public SigningCredentials SigningCredentials { get; }
}
