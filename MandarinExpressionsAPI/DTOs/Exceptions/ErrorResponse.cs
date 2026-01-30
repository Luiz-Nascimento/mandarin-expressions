using System.Net;

namespace MandarinExpressionsAPI.DTOs.Exceptions;

public record ErrorResponse(
    String TraceId,
    HttpStatusCode StatusCode,
    String Message,
    String Route
    );