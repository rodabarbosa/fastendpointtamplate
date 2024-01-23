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

        operationParam
            .Should()
            .NotBeNull();

        operationParam.Operation
            .Should()
            .Be(Operation.Equal);

        operationParam.Value
            .Should()
            .Be(0);
    }
}
