using MediatR;
using FinanceControl.Domain.Entities;
using FinanceControl.Application.Interfaces;
using FinanceControl.Application.Commands;

namespace FinanceControl.Application.Handlers;

public class AddTransactionCommandHandler : IRequestHandler<AddTransactionCommand, Transaction>
{
    private readonly ITransactionRepository _transactionRepository;

    public AddTransactionCommandHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<Transaction> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
    {
        // Use domain factory method with business rules
        var transaction = Transaction.Create(
            request.Amount, 
            request.Category, 
            request.Date, 
            request.Description
        );

        return await _transactionRepository.AddAsync(transaction);
    }
}
