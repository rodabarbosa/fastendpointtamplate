using System.Text.Json.Serialization;

namespace FastEndpointTemplate.Shared.Enumerators;

/// <summary>
/// Enumerator for search operation types
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Operation
{
    /// <summary>
    ///Search by equals
    /// </summary>
    Equal,

    /// <summary>
    /// Search by not equals
    /// </summary>
    NotEqual,

    /// <summary>
    /// Search by greater than
    /// </summary>
    GreaterThan,

    /// <summary>
    /// Search by greater than or equals
    /// </summary>
    GreaterThanOrEqual,

    /// <summary>
    /// Search by less than
    /// </summary>
    LessThan,

    /// <summary>
    /// Search by less than or equals
    /// </summary>
    LessThanOrEqual,

    /// <summary>
    /// Search by contains
    /// </summary>
    Contains,

    /// <summary>
    /// Search by starts with
    /// </summary>
    StartsWith,

    /// <summary>
    /// Search by ends with
    /// </summary>
    EndsWith
}