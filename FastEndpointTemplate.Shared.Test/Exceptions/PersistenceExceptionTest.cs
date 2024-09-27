namespace FastEndpointTemplate.Shared.Test.Exceptions;

public class PersistenceExceptionTest
{
    [Theory]
    [InlineData("Test Exception", true)]
    [InlineData("Test Exception", false)]
    [InlineData(null, true)]
    [InlineData(null, false)]
    public void ThrowException_Param(string? message, bool throws)
    {
        var action = () => PersistenceException.ThrowIf(throws, message);
        if (throws)
            action
                .Should()
                .Throw<PersistenceException>();
        else
            action
                .Should()
                .NotThrow();
    }

    [Fact]
    public void ThrowException_Constructor()
    {
        var exception = new PersistenceException();

        exception.Message
            .Should()
            .NotBeNull();

        exception.InnerException
            .Should()
            .BeNull();
    }

    [Fact]
    public void ThrowException_Constructor1()
    {
        var exception = new PersistenceException("Test Exception");

        exception.Message
            .Should()
            .Be("Test Exception");

        exception.InnerException
            .Should()
            .BeNull();
    }

    [Fact]
    public void ThrowException_Constructor2()
    {
        var exception = new PersistenceException(new Exception("Test Exception"));

        exception.InnerException!
            .Message
            .Should()
            .Be("Test Exception");
    }
}
