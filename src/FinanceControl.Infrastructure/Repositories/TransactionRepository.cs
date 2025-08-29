using FinanceControl.Domain.Entities;
using FinanceControl.Application.Interfaces;
using FinanceControl.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly FinanceControlDbContext _context;

    public TransactionRepository(FinanceControlDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<Transaction> GetByIdAsync(Guid id)
    {
        return await _context.Transactions.FindAsync(id) 
            ?? throw new InvalidOperationException($"Transaction with ID {id} not found");
    }

    public async Task<Transaction> AddAsync(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task<Transaction> UpdateAsync(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task DeleteAsync(Guid id)
    {
        var transaction = await GetByIdAsync(id);
        _context.Transactions.Remove(transaction);
        await _context.SaveChangesAsync();
    }
}
