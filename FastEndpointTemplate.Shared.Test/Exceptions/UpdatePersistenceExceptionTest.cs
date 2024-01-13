namespace FastEndpointTemplate.Shared.Test.Exceptions;

public class UpdatePersistenceExceptionTest
{
    [Theory]
    [InlineData("Test Exception", true)]
    [InlineData("Test Exception", false)]
    [InlineData(null, true)]
    [InlineData(null, false)]
    public void ThrowException_Param(string? message, bool throws)
    {
        if (throws)
            Assert.Throws<UpdatePersistenceException>(() => UpdatePersistenceException.ThrowIf(throws, message));
        else
        {
            UpdatePersistenceException.ThrowIf(throws, message);
            Assert.True(!throws);
        }
    }

    [Fact]
    public void ThrowException_Constructor()
    {
        var exception = new UpdatePersistenceException();
        Assert.NotNull(exception.Message);
        Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ThrowException_Constructor1()
    {
        var exception = new UpdatePersistenceException("Test Exception");
        Assert.Equal("Test Exception", exception.Message);
        Assert.Null(exception.InnerException);
    }

    [Fact]
    public void ThrowException_Constructor2()
    {
        var exception = new UpdatePersistenceException(new Exception("Test Exception"));
        Assert.Equal("Test Exception", exception.InnerException?.Message);
    }
}
