using MandarinExpressionsAPI.Domain;
using MandarinExpressionsAPI.DTOs;

namespace MandarinExpressionsAPI.Services;

public interface IExpressionService
{
    Task<ExpressionResponseDto> GetRandomByLevelAsync(Level level);
    Task<ExpressionResponseDto> CreateAsync(ExpressionRequestDto expression);
}