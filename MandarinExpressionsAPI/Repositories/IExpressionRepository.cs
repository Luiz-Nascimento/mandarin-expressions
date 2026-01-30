using MandarinExpressionsAPI.Domain;

namespace MandarinExpressionsAPI.Repositories;

public interface IExpressionRepository
{
    Task<Expression?> GetByIdAsync(Guid id);
    Task<List<Expression>> GetByLevelAsync(Level level);
    Task AddAsync(Expression expression);
    Task UpdateAsync(Expression expression);
    Task DeleteAsync(Expression expression);

}