namespace FastEndpointTemplate.Shared.Exceptions;

public class PersistenceException : Exception
{
    private const string DefaultMessage = "Persistence Error";

    public PersistenceException() : this(DefaultMessage, default)
    {
    }

    public PersistenceException(string message) : this(message, default)
    {
    }

    public PersistenceException(Exception innerException) : this(DefaultMessage, innerException)
    {
    }

    public PersistenceException(string message, Exception? innerException) : base(DefineMessage(message, DefaultMessage), innerException)
    {
    }

    private static string DefineMessage(string? message, string defaultMessage)
    {
        return string.IsNullOrEmpty(message?.Trim()) ? defaultMessage : message;
    }

    public static void ThrowIf(bool condition, string? message, Exception? innerException = null)
    {
        if (condition) throw new PersistenceException(message, innerException);
    }
}
