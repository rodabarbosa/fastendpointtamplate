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
        if (throws)
            Assert.Throws<DeletePersistenceException>(() => DeletePersistenceException.ThrowIf(throws, message));
        else
        {
            DeletePersistenceException.ThrowIf(throws, message);
            Assert.True(!throws);
        }
    }

    [Fact]
    public void ThrowException_Constructor()
    {
        var exception = new DeletePersistenceException();
        Assert.NotNull(exception.Message);
        Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ThrowException_Constructor1()
    {
        var exception = new DeletePersistenceException("Test Exception");
        Assert.Equal("Test Exception", exception.Message);
        Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ThrowException_Constructor2()
    {
        var exception = new DeletePersistenceException(new Exception("Test Exception"));
        Assert.Equal("Test Exception", exception.InnerException?.Message);
    }
}
