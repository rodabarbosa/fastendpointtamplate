namespace FastEndpointTemplate.Shared.Test.Exceptions;

public class BadRequestExceptionTest
{
    [Theory]
    [InlineData("Test Exception", true)]
    [InlineData("Test Exception", false)]
    [InlineData(null, true)]
    [InlineData(null, false)]
    public void ThrowException_Param(string? message, bool throws)
    {
        var action = () => BadRequestException.ThrowIf(throws, message);
        if (throws)
            action
                .Should()
                .Throw<BadRequestException>();
        else
            action
                .Should()
                .NotThrow();
    }

    [Fact]
    public void ThrowException_Constructor()
    {
        var exception = new BadRequestException();
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
        var exception = new BadRequestException("Test Exception");
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
        var exception = new BadRequestException(new Exception("Test Exception"));
        exception.InnerException!
            .Message
            .Should()
            .Be("Test Exception");
    }
}
