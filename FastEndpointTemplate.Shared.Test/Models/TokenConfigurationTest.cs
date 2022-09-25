namespace FastEndpointTemplate.Shared.Test.Models;

public class TokenConfigurationTest
{
    [Fact]
    public void TokenConfiguration_ShouldBeValid()
    {
        var tokenConfiguration = new TokenConfiguration();

        Assert.NotNull(tokenConfiguration);
        Assert.NotNull(tokenConfiguration.Issuer);
        Assert.NotNull(tokenConfiguration.Audience);
        Assert.NotNull(tokenConfiguration.Seconds);
        Assert.True(tokenConfiguration.Seconds > 0);
    }

    [Theory]
    [InlineData("test", 10)]
    public void TokenConfiguration_ShouldBeCreated(string text, int value)
    {
        var tokenConfiguration = new TokenConfiguration
        {
            Audience = text,
            Issuer = text,
            Seconds = value
        };

        Assert.NotNull(tokenConfiguration);
        Assert.Equal(text, tokenConfiguration.Issuer);
        Assert.Equal(text, tokenConfiguration.Audience);
        Assert.Equal(value, tokenConfiguration.Seconds);
    }
}
