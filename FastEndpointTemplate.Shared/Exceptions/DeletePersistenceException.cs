namespace FastEndpointTemplate.Shared.Exceptions;

public class DeletePersistenceException : Exception
{
    private const string DefaultMessage = "Error deleting data.";

    public DeletePersistenceException() : this(DefaultMessage, default)
    {
    }

    public DeletePersistenceException(string message) : this(message, default)
    {
    }

    public DeletePersistenceException(Exception innerException) : this(DefaultMessage, innerException)
    {
    }

    public DeletePersistenceException(string message, Exception? innerException) : base(DefineMessage(message, DefaultMessage), innerException)
    {
    }

    private static string DefineMessage(string? message, string defaultMessage)
    {
        return string.IsNullOrEmpty(message?.Trim()) ? defaultMessage : message;
    }

    public static void ThrowIf(bool condition, string? message, Exception? innerException = null)
    {
        if (condition) throw new DeletePersistenceException(message, innerException);
    }
}
