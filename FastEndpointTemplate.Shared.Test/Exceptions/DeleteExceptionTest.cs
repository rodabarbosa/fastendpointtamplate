namespace FastEndpointTemplate.Shared.Test.Exceptions;

public class DeleteExceptionTest
{
    [Theory]
    [InlineData("Test Exception", true)]
    [InlineData("Test Exception", false)]
    [InlineData(null, true)]
    [InlineData(null, false)]
    public void ThrowException_Param(string? message, bool throws)
    {
        var action = () => DeletePersistenceException.ThrowIf(throws, message);
        if (throws)
            action
                .Should()
                .Throw<DeletePersistenceException>();
        else
            action
                .Should()
                .NotThrow();
    }

    [Fact]
    public void ThrowException_Constructor()
    {
        var exception = new DeletePersistenceException();

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
        var exception = new DeletePersistenceException("Test Exception");

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
        var exception = new DeletePersistenceException(new Exception("Test Exception"));

        exception.InnerException!
            .Message
            .Should()
            .Be("Test Exception");
    }
}
