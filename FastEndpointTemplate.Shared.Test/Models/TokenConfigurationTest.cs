namespace FastEndpointTemplate.Shared.Test.Models;

public class TokenConfigurationTest
{
    [Fact]
    public void TokenConfiguration_ShouldBeValid()
    {
        var tokenConfiguration = new TokenConfiguration();

        tokenConfiguration.Should()
            .NotBeNull();

        tokenConfiguration.Issuer
            .Should()
            .NotBeNull();

        tokenConfiguration.Audience
            .Should()
            .NotBeNull();

        tokenConfiguration.Seconds
            .Should()
            .BeGreaterThan(0);
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

        tokenConfiguration
            .Should()
            .NotBeNull();

        tokenConfiguration.Issuer
            .Should()
            .Be(text);

        tokenConfiguration.Audience
            .Should()
            .Be(text);
        tokenConfiguration.Seconds
            .Should()
            .Be(value);
    }
}
