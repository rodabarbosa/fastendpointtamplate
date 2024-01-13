using FastEndpointTemplate.Domain.Repositories;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;
using FastEndpointTemplate.Shared.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace FastEndpointTemplate.Application.Handlers.Authentications;

public class AuthenticationHandler(
    IUserRepository userRepository,
    ISigningConfiguration signingConfiguration,
    ITokenConfiguration tokenConfiguration)
    : IAuthenticationHandler
{
    public async Task<AuthenticationResponseContract> HandleAsync(AuthenticationContract contract, CancellationToken cancellationToken)
    {
        var validCredentials = await userRepository.IsUserValidAsync(contract.Username!, contract.Password!, cancellationToken);
        BadRequestException.ThrowIf(!validCredentials, "Não foi possível autenticar o usuário");

        var identity = CreateIdentity();

        return CreateAuthenticationResponse(identity, contract.Username!);
    }

    private static ClaimsIdentity CreateIdentity()
    {
        var claim = Guid.NewGuid().ToString("N");
        return new ClaimsIdentity(new GenericIdentity(Guid.NewGuid().ToString("N"), "Login"),
            new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, claim),
                new Claim(JwtRegisteredClaimNames.UniqueName, claim)
            }
        );
    }

    private AuthenticationResponseContract CreateAuthenticationResponse(ClaimsIdentity identity, string username)
    {
        var createdDate = DateTime.Now;
        var expiresDate = createdDate + TimeSpan.FromSeconds(tokenConfiguration.Seconds);

        var token = CreateToken(identity,
            signingConfiguration,
            tokenConfiguration,
            createdDate,
            expiresDate);

        return new AuthenticationResponseContract
        {
            Expires = expiresDate,
            Token = token,
            Username = username,
            CreatedAt = createdDate
        };
    }

    private static string CreateToken(ClaimsIdentity identity, ISigningConfiguration signingConfiguration, ITokenConfiguration tokenConfiguration, DateTime createdDate, DateTime expiresDate)
    {
        var handler = new JwtSecurityTokenHandler();
        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        {
            Issuer = tokenConfiguration.Issuer,
            Audience = tokenConfiguration.Audience,
            SigningCredentials = signingConfiguration.SigningCredentials,
            Subject = identity,
            NotBefore = createdDate,
            Expires = expiresDate
        });

        return handler.WriteToken(securityToken);
    }
}
