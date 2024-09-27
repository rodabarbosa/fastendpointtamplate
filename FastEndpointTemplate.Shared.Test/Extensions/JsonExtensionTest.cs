namespace FastEndpointTemplate.Shared.Test.Extensions;

public class JsonExtensionTest
{
    private const string JsonTest = "{\"code\":1,\"error\":\"Test Error\",\"exception\":\"Test Exception\",\"stackTrace\":\"Test StackTrace\"}";

    [Fact]
    public void ToJson_Should_Return_Json_String()
    {
        var testObject = new ErrorContract
        {
            Code = 1,
            Error = "Test Error",
            Exception = "Test Exception",
            StackTrace = "Test StackTrace"
        };

        var json = testObject.ToJson();

        json
            .Should()
            .Be(JsonTest);
    }

    [Fact]
    public void FromJson_Should_Return_Object()
    {
        var testObject = JsonTest.FromJson<ErrorContract>();

        testObject
            .Should()
            .NotBeNull();

        testObject!.Code
            .Should()
            .Be(1);

        testObject.Error!.ToString()
            .Should()
            .Be("Test Error");

        testObject.Exception
            .Should()
            .Be("Test Exception");

        testObject.StackTrace
            .Should()
            .Be("Test StackTrace");
    }

    [Fact]
    public void FromJson_ReturnNull()
    {
        var json = string.Empty;
        var testObject = json.FromJson<ErrorContract>();

        testObject
            .Should()
            .BeNull();
    }
}
