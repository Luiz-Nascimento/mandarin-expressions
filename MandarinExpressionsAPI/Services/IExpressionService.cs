using MandarinExpressionsAPI.Domain;
using MandarinExpressionsAPI.DTOs;

namespace MandarinExpressionsAPI.Services;

public interface IExpressionService
{
    Task<List<ExpressionResponseDto>> GetAllAsync();
    Task<ExpressionResponseDto> GetRandomByLevelAsync(Level level);
    Task<ExpressionResponseDto> CreateAsync(ExpressionRequestDto expression);

    Task<ExpressionResponseDto> GetByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
}