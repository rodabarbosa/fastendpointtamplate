namespace FastEndpointTemplate.Shared.Test.Models;

public class SigningConfigurationTest
{
    [Fact]
    public void SigningConfiguration_ShouldBeValid()
    {
        var signingConfiguration = new SigningConfiguration();

        Assert.NotNull(signingConfiguration);
        Assert.NotNull(signingConfiguration.Key);
        Assert.NotNull(signingConfiguration.SigningCredentials);
    }
}
