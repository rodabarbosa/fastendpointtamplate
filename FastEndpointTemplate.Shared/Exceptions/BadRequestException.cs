namespace FastEndpointTemplate.Shared.Exceptions;

public class BadRequestException : Exception
{
    private const string DefaultMessage = "Bad Request";

    public BadRequestException() : this(DefaultMessage)
    {
    }

    public BadRequestException(string? message) : this(message, default)
    {
    }

    public BadRequestException(Exception? innerException) : this(DefaultMessage, innerException)
    {
    }

    public BadRequestException(string? message, Exception? innerException) : base(DefineMessage(message, DefaultMessage), innerException)
    {
    }

    private static string DefineMessage(string? message, string defaultMessage)
    {
        return string.IsNullOrEmpty(message?.Trim()) ? defaultMessage : message;
    }

    public static void ThrowIf(bool condition, string? message, Exception? innerException = null)
    {
        if (condition) throw new BadRequestException(message, innerException);
    }
}
