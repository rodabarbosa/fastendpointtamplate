using FastEndpointTemplate.Shared.Jwt;

namespace FastEndpointTemplate.Shared.Models;

/// <inheritdoc />
public sealed class TokenConfiguration : ITokenConfiguration
{
    /// <inheritdoc />
    public string Audience { get; set; } = "FastEndpointTemplateAudience";

    /// <inheritdoc />
    public string Issuer { get; set; } = "FastEndpointTemplateIssuer";

    /// <inheritdoc />
    public int Seconds { get; set; } = 60;
}
