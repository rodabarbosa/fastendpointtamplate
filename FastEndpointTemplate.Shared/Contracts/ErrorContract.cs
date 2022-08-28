using System.Text.Json.Serialization;

namespace FastEndpointTemplate.Shared.Contracts;

public sealed class ErrorContract
{
    public int Code { get; init; }
    public object? Error { get; init; }
    public string? Exception { get; init; }
    [JsonIgnore] public string StackTrace { get; init; }
}
