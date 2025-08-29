using MediatR;
using FinanceControl.Domain.Entities;
using FinanceControl.Application.Interfaces;
using FinanceControl.Application.Queries;

namespace FinanceControl.Application.Handlers;

public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, IEnumerable<Transaction>>
{
    private readonly ITransactionRepository _transactionRepository;

    public GetTransactionsQueryHandler(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task<IEnumerable<Transaction>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
    {
        return await _transactionRepository.GetAllAsync();
    }
}
