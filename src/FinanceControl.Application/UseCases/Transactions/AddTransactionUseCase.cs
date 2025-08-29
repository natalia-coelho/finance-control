using FinanceControl.Domain.Entities;
using FinanceControl.Application.Interfaces;

namespace FinanceControl.Application.UseCases.Transactions;

public class AddTransactionUseCase
{
    private readonly ITransactionRepository _transactionRepository;

    public AddTransactionUseCase(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Transaction> ExecuteAsync(decimal amount, string category, DateTime date, string? description = null)
    {
        // Application layer business logic
        if (amount > 10000)
        {
            throw new InvalidOperationException("Transaction amount exceeds maximum limit");
        }

        // Use domain entity factory
        var transaction = Transaction.Create(amount, category, date, description);
        
        // Persist through repository
        return await _transactionRepository.AddAsync(transaction);
    }
}
