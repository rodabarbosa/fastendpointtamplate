namespace FastEndpointTemplate.Shared.Exceptions;

public class UpdatePersistenceException : Exception
{
    private const string DefaultMessage = "Error updating data.";

    public UpdatePersistenceException() : this(DefaultMessage, default)
    {
    }

    public UpdatePersistenceException(string message) : this(message, default)
    {
    }

    public UpdatePersistenceException(Exception innerException) : this(DefaultMessage, innerException)
    {
    }

    public UpdatePersistenceException(string? message, Exception? innerException) : base(DefineMessage(message, DefaultMessage), innerException)
    {
    }

    private static string DefineMessage(string? message, string defaultMessage)
    {
        return string.IsNullOrEmpty(message?.Trim()) ? defaultMessage : message;
    }

    public static void ThrowIf(bool condition, string? message, Exception? innerException = null)
    {
        if (condition) throw new UpdatePersistenceException(message, innerException);
    }
}
