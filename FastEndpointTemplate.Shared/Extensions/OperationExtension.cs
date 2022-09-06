using FastEndpointTemplate.Shared.Enumerators;

namespace FastEndpointTemplate.Shared.Extensions;

/// <summary>
/// Operation Extension
/// </summary>
public static class OperationExtension
{
    /// <summary>
    /// Convert string to Operation enum
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Operation ToOperation(this string value)
    {
        if (string.Equals(value, nameof(Operation.Equal), StringComparison.OrdinalIgnoreCase))
            return Operation.Equal;

        if (string.Equals(value, nameof(Operation.NotEqual), StringComparison.OrdinalIgnoreCase))
            return Operation.NotEqual;

        if (string.Equals(value, nameof(Operation.GreaterThan), StringComparison.OrdinalIgnoreCase))
            return Operation.GreaterThan;

        if (string.Equals(value, nameof(Operation.GreaterThanOrEqual), StringComparison.OrdinalIgnoreCase))
            return Operation.GreaterThanOrEqual;

        if (string.Equals(value, nameof(Operation.LessThan), StringComparison.OrdinalIgnoreCase))
            return Operation.LessThan;

        if (string.Equals(value, nameof(Operation.LessThanOrEqual), StringComparison.OrdinalIgnoreCase))
            return Operation.LessThanOrEqual;

        if (string.Equals(value, nameof(Operation.Contains), StringComparison.OrdinalIgnoreCase))
            return Operation.Contains;

        if (string.Equals(value, nameof(Operation.StartsWith), StringComparison.OrdinalIgnoreCase))
            return Operation.StartsWith;

        if (string.Equals(value, nameof(Operation.EndsWith), StringComparison.OrdinalIgnoreCase))
            return Operation.EndsWith;

        return Operation.Equal;
    }
}
