using FastEndpoints;
using FastEndpointTemplate.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabase("Template");

builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();

builder.Services.AddSwagger();

var app = builder.Build();

app.UseAuthorization();
app.UseFastEndpoints();

app.UseSwaggerDoc();

app.Run();
