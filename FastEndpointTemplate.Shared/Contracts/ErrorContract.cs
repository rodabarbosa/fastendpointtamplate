namespace FastEndpointTemplate.Shared.Contracts;

public sealed class ErrorContract(int code, object? error, string? exception, string? stackTrace)
{
    private const int DefaultCode = 400; // Bad request int

    public ErrorContract()
        : this(DefaultCode, null, null, null)
    {
    }

    public int Code { get; init; } = code;
    public object? Error { get; init; } = error;
    public string? Exception { get; init; } = exception;
    public string? StackTrace { get; init; } = stackTrace;
}
