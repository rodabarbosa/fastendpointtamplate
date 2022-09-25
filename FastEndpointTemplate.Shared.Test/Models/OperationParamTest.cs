namespace FastEndpointTemplate.Shared.Test.Models;

public class OperationParamTest
{
    [Fact]
    public void OperationParam_ShouldBeValid()
    {
        var operationParam = new OperationParam<int>
        {
            Operation = Operation.Equal,
            Value = 0
        };

        Assert.NotNull(operationParam);
        Assert.NotNull(operationParam.Operation);
        Assert.Equal(Operation.Equal, operationParam.Operation);

        Assert.NotNull(operationParam.Value);
        Assert.IsType<int>(operationParam.Value);
        Assert.Equal(0, operationParam.Value);
    }
}
