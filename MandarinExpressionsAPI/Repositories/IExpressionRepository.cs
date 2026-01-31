using MandarinExpressionsAPI.Domain;

namespace MandarinExpressionsAPI.Repositories;

public interface IExpressionRepository
{
    Task<Expression?> GetByIdAsync(Guid id);

    IQueryable<Expression> GetAll();
    Task<List<Expression>> GetByLevelAsync(Level level);
    Task AddAsync(Expression expression);
    Task UpdateAsync(Expression expression);
    Task DeleteAsync(Expression expression);

    Task<bool> ExistsByHanziAsync(string hanzi);

}