namespace FastEndpointTemplate.Shared.Test.Extensions;

public class OperationExtensionTest
{
    [Theory]
    [InlineData(0, "equal")]
    [InlineData(1, "notequal")]
    [InlineData(2, "GreaterThan")]
    [InlineData(3, "GreaterThanOrEqual")]
    [InlineData(4, "lessThan")]
    [InlineData(5, "lessThanOrEqual")]
    [InlineData(6, "Contains")]
    [InlineData(7, "StartsWith")]
    [InlineData(8, "EndsWith")]
    [InlineData(0, "Fail")]
    public void ToOperation_test(int value, string operationStr)
    {
        var operation = (Operation)value;
        var testing = operationStr.ToOperation();

        testing
            .Should()
            .Be(operation);
    }
}
