namespace FastEndpointTemplate.Shared.Exceptions;

public class AddPersistenceException : Exception
{
    private const string DefaultMessage = "Error while adding data.";

    public AddPersistenceException()
    {
    }

    public AddPersistenceException(string message) : this(message, default)
    {
    }

    public AddPersistenceException(Exception innerException) : this(DefaultMessage, innerException)
    {
    }

    public AddPersistenceException(string message, Exception? innerException) : base(DefineMessage(message, DefaultMessage), innerException)
    {
    }

    private static string DefineMessage(string? message, string defaultMessage)
    {
        return string.IsNullOrEmpty(message?.Trim()) ? defaultMessage : message;
    }

    public static void ThrowIf(bool condition, string? message, Exception? innerException = null)
    {
        if (condition) throw new AddPersistenceException(message, innerException);
    }
}
