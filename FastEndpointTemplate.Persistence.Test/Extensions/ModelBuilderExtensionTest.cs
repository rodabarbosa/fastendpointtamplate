namespace FastEndpointTemplate.Persistence.Test.Extensions;

public class ModelBuilderExtensionTest
{
    [Fact]
    public void ModelBuilder_Seeds()
    {
        var modelBuilder = new ModelBuilder();
        modelBuilder.SetSeeds();
    }
}
