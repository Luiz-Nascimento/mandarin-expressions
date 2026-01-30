using System.Diagnostics;
using System.Net;
using MandarinExpressionsAPI.DTOs.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Extensions;

namespace MandarinExpressionsAPI.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var (statusCode, title) = exception switch
        {
            ArgumentException => (StatusCodes.Status400BadRequest, "Bad Request"),

            _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
        };
        httpContext.Response.StatusCode = statusCode;
        ErrorResponse response =
            new ErrorResponse(
                httpContext.TraceIdentifier,
                title,
                (HttpStatusCode)statusCode,
                exception.Message,
                httpContext.Request.Path);
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}