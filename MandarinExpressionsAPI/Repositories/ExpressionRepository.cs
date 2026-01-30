using MandarinExpressionsAPI.Domain;
using MandarinExpressionsAPI.Infra;
using Microsoft.EntityFrameworkCore;

namespace MandarinExpressionsAPI.Repositories;

public class ExpressionRepository : IExpressionRepository
{
    private readonly AppDbContext _context;

    public ExpressionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Expression?> GetByIdAsync(Guid id)
    {
        return await _context.Expressions.FindAsync(id);
    }

    public async Task<List<Expression>> GetByLevelAsync(Level level)
    {
        return await _context.Expressions
            .Where(e => e.Level == level)
            .ToListAsync();
    }

    public async Task AddAsync(Expression expression)
    {
        _context.AddAsync(expression);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Expression expression)
    {
        _context.Expressions.Update(expression);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Expression expression)
    {
        _context.Expressions.Remove(expression);
        await _context.SaveChangesAsync();
    }
}