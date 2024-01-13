global using FluentValidation;
using FastEndpoints;
using FastEndpointTemplate.Api.Extensions;
using FastEndpointTemplate.Api.Models;
using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression();

var configuration = builder.Configuration;

var tokenConfigurations = new TokenConfiguration();
new ConfigureFromConfigurationOptions<TokenConfiguration>(configuration.GetSection("TokenConfiguration"))
    .Configure(tokenConfigurations);

builder.Services.AddJwtService(tokenConfigurations);

builder.Services.AddDatabase("Template");
builder.Services.AddHandlers();

builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();

var apiInfo = new ApiInfo();
new ConfigureFromConfigurationOptions<ApiInfo>(configuration.GetSection("ApiInfo"))
    .Configure(apiInfo);

builder.Services.AddSwagger(apiInfo);

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

    c.Serializer.RequestDeserializer = async (httpRequest, type, jCtx, ct) =>
    {
        using var reader = new StreamReader(httpRequest.Body);
        var bodyRequest = await reader.ReadToEndAsync();
        return JsonSerializer.Deserialize(bodyRequest, type, serializerOptions);
    };

    c.Serializer.ResponseSerializer = (httpResponse, response, contentType, jCtx, ct) =>
    {
        httpResponse.ContentType = contentType;
        var responseText = JsonSerializer.Serialize(response, serializerOptions);
        return httpResponse.WriteAsync(responseText, ct);
    };

    // Handles Validation errors
    c.Errors.ResponseBuilder = (failures, ctx, status) =>
    {
        var errorMessages = new Dictionary<string, string>();
        foreach (var failure in failures)
        {
            errorMessages.Add(failure.PropertyName, failure.ErrorMessage);
        }

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

app.UseHttpsRedirection();

app.Run();
