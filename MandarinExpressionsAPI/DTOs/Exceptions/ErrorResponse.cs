using System.Net;

namespace MandarinExpressionsAPI.DTOs.Exceptions;

public record ErrorResponse(
    String TraceId,
    String Title,
    HttpStatusCode StatusCode,
    String Message,
    String Route
    );