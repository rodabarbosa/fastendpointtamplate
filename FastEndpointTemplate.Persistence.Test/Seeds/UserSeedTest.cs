namespace FastEndpointTemplate.Persistence.Test.Seeds;

public class UserSeedTest
{
    [Fact]
    public void GetUserSeeds_Valid()
    {
        var result = UserSeed.GetSeeds();

        Assert.NotEmpty(result);
    }
}
