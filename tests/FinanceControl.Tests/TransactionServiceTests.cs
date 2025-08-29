using Xunit;
using FinanceControl.Domain.Entities;
using FinanceControl.Infrastructure.Data;
using FinanceControl.Infrastructure.Repositories;
using FinanceControl.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Tests;

public class TransactionServiceTests
{
    private readonly FinanceControlDbContext _context;
    private readonly ITransactionRepository _repository;

    public TransactionServiceTests()
    {
        var options = new DbContextOptionsBuilder<FinanceControlDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        
        _context = new FinanceControlDbContext(options);
        _repository = new TransactionRepository(_context);
    }

    [Fact]
    public async Task AddTransaction_ShouldCreateNewTransaction()
    {
        // Arrange
        var transaction = Transaction.Create(100.50m, "Food", DateTime.UtcNow, "Lunch");

        // Act
        var result = await _repository.AddAsync(transaction);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(transaction.Id, result.Id);
        Assert.Equal(transaction.Amount, result.Amount);
        Assert.Equal(transaction.Category, result.Category);
    }

    [Fact]
    public async Task GetTransactions_ShouldReturnAllTransactions()
    {
        // Arrange
        var transaction1 = Transaction.Create(50.00m, "Transport", DateTime.UtcNow, "Bus fare");
        var transaction2 = Transaction.Create(25.75m, "Food", DateTime.UtcNow, "Coffee");

        await _repository.AddAsync(transaction1);
        await _repository.AddAsync(transaction2);

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }

    [Fact]
    public void Transaction_Create_WithInvalidAmount_ShouldThrowException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => Transaction.Create(-100m, "Food", DateTime.UtcNow));
    }

    [Fact]
    public void Transaction_Create_WithEmptyCategory_ShouldThrowException()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => Transaction.Create(100m, "", DateTime.UtcNow));
    }
}
