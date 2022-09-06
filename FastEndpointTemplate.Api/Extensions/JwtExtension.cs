using FastEndpointTemplate.Shared.Jwt;
using FastEndpointTemplate.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace FastEndpointTemplate.Api.Extensions;

public static class JwtExtension
{
    /// <summary>
    /// Add JWT configuration to services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        var signingConfigurations = new SigningConfiguration();
        services.AddSingleton(typeof(ISigningConfiguration), signingConfigurations);

        var tokenConfigurations = new TokenConfiguration();
        new ConfigureFromConfigurationOptions<TokenConfiguration>(configuration.GetSection("TokenConfiguration"))
            .Configure(tokenConfigurations);
        services.AddSingleton(typeof(ITokenConfiguration), tokenConfigurations);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.Events.OnRedirectToAccessDenied =
                    options.Events.OnRedirectToLogin = c =>
                    {
                        c.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.FromResult<object>(null!);
                    };
            })
            .AddJwtBearer(options =>
            {
                options.IncludeErrorDetails = true;
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;

                var paramsValidation = options.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

        services.AddAuthorization(options =>
        {
            options.InvokeHandlersAfterFailure = true;
            options.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser().Build());
        });
    }
}
