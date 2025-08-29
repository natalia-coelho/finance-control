namespace FinanceControl.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    ITransactionRepository Transactions { get; }
    Task<int> SaveChangesAsync();
}
