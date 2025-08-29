using MediatR;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Application.Commands;

public record AddTransactionCommand : IRequest<Transaction>
{
    public decimal Amount { get; init; }
    public string Category { get; init; } = string.Empty;
    public DateTime Date { get; init; }
    public string? Description { get; init; }
}
