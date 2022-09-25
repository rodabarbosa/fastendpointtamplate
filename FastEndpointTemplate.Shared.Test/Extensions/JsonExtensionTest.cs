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

        Assert.Equal(JsonTest, json);
    }

    [Fact]
    public void FromJson_Should_Return_Object()
    {
        var testObject = JsonTest.FromJson<ErrorContract?>();

        Assert.NotNull(testObject);

        Assert.Equal(1, testObject?.Code);
        Assert.Equal("Test Error", testObject?.Error?.ToString());
        Assert.Equal("Test Exception", testObject?.Exception);
        Assert.Equal("Test StackTrace", testObject?.StackTrace);
    }

    [Fact]
    public void FromJson_ReturnNull()
    {
        var json = string.Empty;
        var testObject = json.FromJson<ErrorContract?>();
        Assert.Null(testObject);
    }
}
