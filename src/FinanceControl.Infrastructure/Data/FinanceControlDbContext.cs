using Microsoft.EntityFrameworkCore;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Infrastructure.Data;

public class FinanceControlDbContext : DbContext
{
    public FinanceControlDbContext(DbContextOptions<FinanceControlDbContext> options) : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Amount).HasPrecision(18, 2);
            entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
        });
    }
}
