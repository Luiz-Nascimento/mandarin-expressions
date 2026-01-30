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
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        ErrorResponse response =
            new ErrorResponse(
                httpContext.TraceIdentifier,
                HttpStatusCode.InternalServerError,
                exception.Message,
                httpContext.Request.Path);
        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true;
    }
}