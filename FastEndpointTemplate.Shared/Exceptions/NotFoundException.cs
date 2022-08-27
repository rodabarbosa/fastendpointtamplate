namespace FastEndpointTemplate.Shared.Exceptions;

public class NotFoundException : Exception
{
    private const string DefaultMessage = "Not Found";

    public NotFoundException() : this(DefaultMessage)
    {
    }

    public NotFoundException(string message) : this(message, default)
    {
    }

    public NotFoundException(Exception innerException) : this(DefaultMessage, innerException)
    {
    }

    public NotFoundException(string message, Exception innerException) : base(DefineMessage(message, DefaultMessage), innerException)
    {
    }

    private static string DefineMessage(string message, string defaultMessage)
    {
        return string.IsNullOrEmpty(message?.Trim()) ? defaultMessage : message;
    }

    public static void ThrowIf(bool condition, string message, Exception innerException = default)
    {
        if (condition) throw new NotFoundException(message, innerException);
    }
}
