using MandarinExpressionsAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace MandarinExpressionsAPI.Infra;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Expression> Expressions => Set<Expression>();
}