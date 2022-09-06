using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FastEndpointTemplate.Shared.Extensions;

public static class JsonExtension
{
    private static readonly JsonSerializerOptions _jsonSerializerOptionsDeserialization = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = false,
        Encoder = JavaScriptEncoder.Default,
        IgnoreReadOnlyFields = true,
        IgnoreReadOnlyProperties = true
    };

    private static readonly JsonSerializerOptions _jsonSerializerOptionsSerialization = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        WriteIndented = false,
        Encoder = JavaScriptEncoder.Default,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public static string ToJson(this object? value)
    {
        return JsonSerializer.Serialize(value, _jsonSerializerOptionsSerialization);
    }

    public static T? FromJson<T>(this string? value) where T : class
    {
        if (string.IsNullOrEmpty(value?.Trim()))
            return default;

        return JsonSerializer.Deserialize<T?>(value, _jsonSerializerOptionsDeserialization);
    }
}
