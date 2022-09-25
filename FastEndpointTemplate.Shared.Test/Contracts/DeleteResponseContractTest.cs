namespace FastEndpointTemplate.Shared.Test.Contracts;

public class DeleteTest
{
    [Fact]
    public void Delete_ShouldBeCreated()
    {
        var delete = new DeleteResponseContract
        {
            Success = true
        };

        Assert.NotNull(delete);
        Assert.True(delete.Success);
    }
}
