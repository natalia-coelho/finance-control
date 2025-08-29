using MediatR;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Application.Queries;

public record GetTransactionsQuery : IRequest<IEnumerable<Transaction>>
{
}
