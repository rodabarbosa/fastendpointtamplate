using FastEndpointTemplate.Shared.Contracts;
using FastEndpointTemplate.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace FastEndpointTemplate.Api.Extensions;

public static class ExceptionHandlerExtension
{
    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(errApp =>
        {
            errApp.Run(async ctx =>
            {
                ctx.Response.ContentType = "application/problem+json";
                var exHandlerFeature = ctx.Features.Get<IExceptionHandlerFeature>();
                if (exHandlerFeature is null)
                {
                    var errorCode = (int)HttpStatusCode.InternalServerError;
                    ctx.Response.StatusCode = errorCode;
                    await ctx.Response.WriteAsJsonAsync(new ErrorContract
                    {
                        Code = errorCode,
                        Error = "Ops! Something went wrong.",
                        Exception = "InternalServiceException",
                        StackTrace = default
                    });
                }

                var error = GetErrorMessage(exHandlerFeature?.Error);

                ctx.Response.StatusCode = error.Code;
                await ctx.Response.WriteAsJsonAsync(error);
            });
        });
    }

    private static ErrorContract GetErrorMessage(Exception? exception)
    {
        if (exception is null)
        {
            return new ErrorContract
            {
                Code = (int)HttpStatusCode.BadRequest,
                Error = "Ops! Something went wrong.",
                Exception = default,
                StackTrace = default
            };
        }

        return exception switch
        {
            NotFoundException => new ErrorContract
            {
                Code = (int)HttpStatusCode.NotFound,
                Error = exception.Message,
                Exception = nameof(NotFoundException),
                StackTrace = exception.StackTrace
            },
            BadRequestException => new ErrorContract
            {
                Code = (int)HttpStatusCode.BadRequest,
                Error = exception.Message,
                Exception = nameof(BadRequestException),
                StackTrace = exception.StackTrace
            },
            PersistenceException => new ErrorContract
            {
                Code = (int)HttpStatusCode.BadRequest,
                Error = exception.Message,
                Exception = nameof(BadRequestException),
                StackTrace = exception.StackTrace
            },
            AddPersistenceException => new ErrorContract
            {
                Code = (int)HttpStatusCode.BadRequest,
                Error = exception.Message,
                Exception = nameof(BadRequestException),
                StackTrace = exception.StackTrace
            },
            DeletePersistenceException => new ErrorContract
            {
                Code = (int)HttpStatusCode.BadRequest,
                Error = exception.Message,
                Exception = nameof(BadRequestException),
                StackTrace = exception.StackTrace
            },
            UpdatePersistenceException => new ErrorContract
            {
                Code = (int)HttpStatusCode.BadRequest,
                Error = exception.Message,
                Exception = nameof(BadRequestException),
                StackTrace = exception.StackTrace
            },
            _ => new ErrorContract
            {
                Code = (int)HttpStatusCode.BadRequest,
                Error = "Ops! Something went wrong.",
                Exception = exception.GetType().Name,
                StackTrace = exception.StackTrace
            }
        };
    }
}
