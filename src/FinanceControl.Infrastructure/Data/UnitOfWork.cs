using FinanceControl.Application.Interfaces;
using FinanceControl.Infrastructure.Repositories;

namespace FinanceControl.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly FinanceControlDbContext _context;
    private ITransactionRepository? _transactionRepository;

    public UnitOfWork(FinanceControlDbContext context)
    {
        _context = context;
    }

    public ITransactionRepository Transactions => 
        _transactionRepository ??= new TransactionRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
