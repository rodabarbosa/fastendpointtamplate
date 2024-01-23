namespace FastEndpointTemplate.Shared.Contracts;

public sealed class ErrorContract(int code, object? error, string? exception, string? stackTrace)
{
    public ErrorContract()
        : this(400, null, null, null)
    {
    }

    public int Code { get; init; } = code;
    public object? Error { get; init; } = error;
    public string? Exception { get; init; } = exception;
    public string? StackTrace { get; init; } = stackTrace;
}
