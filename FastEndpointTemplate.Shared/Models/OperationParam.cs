using FastEndpointTemplate.Shared.Enumerators;

namespace FastEndpointTemplate.Shared.Models;

/// <summary>
/// Container for search params in list methods
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class OperationParam<T>(Operation operation, T value)
{
    public OperationParam()
        : this(default, default!)
    {
    }

    /// <summary>
    /// Defines operation type
    /// </summary>
    public Operation Operation { get; set; } = operation;

    /// <summary>
    /// Defines search value
    /// </summary>
    public T Value { get; set; } = value;
}
