namespace FastEndpointTemplate.Shared.Test.Models;

public class SigningConfigurationTest
{
    [Fact]
    public void SigningConfiguration_ShouldBeValid()
    {
        var signingConfiguration = new SigningConfiguration();

        signingConfiguration
            .Should()
            .NotBeNull();

        signingConfiguration.Key
            .Should()
            .NotBeNull();

        signingConfiguration.SigningCredentials
            .Should()
            .NotBeNull();
    }
}
