global using FluentValidation;
using FastEndpoints;
using FastEndpointTemplate.Api.Extensions;
using FastEndpointTemplate.Shared.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression();

builder.Services.AddDatabase("Template");

builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseResponseCompression();

app.UseCustomExceptionHandler();

app.UseAuthorization();
app.UseFastEndpoints(c =>
{
    var serializerOptions = new JsonSerializerOptions
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        IgnoreReadOnlyFields = true,
        IgnoreReadOnlyProperties = true,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        UnknownTypeHandling = JsonUnknownTypeHandling.JsonElement,
        WriteIndented = false
    };

    c.RequestDeserializer = async (httpRequest, type, jCtx, ct) =>
    {
        using var reader = new StreamReader(httpRequest.Body);
        var bodyRequest = await reader.ReadToEndAsync();
        return JsonSerializer.Deserialize(bodyRequest, type, serializerOptions);
    };

    c.ResponseSerializer = (httpResponse, response, contentType, jCtx, ct) =>
    {
        httpResponse.ContentType = contentType;
        var responseText = JsonSerializer.Serialize(response, serializerOptions);
        return httpResponse.WriteAsync(responseText, ct);
    };

    // Handles Valdiation errors
    c.ErrorResponseBuilder = (failures, status) =>
    {
        var errorMessages = new Dictionary<string, string>();
        foreach (var failure in failures) errorMessages.Add(failure.PropertyName, failure.ErrorMessage);

        return new ErrorContract
        {
            Code = status,
            Error = errorMessages,
            Exception = nameof(ValidationException),
            StackTrace = default
        };
    };
});

app.UseSwaggerDoc();

app.Run();
