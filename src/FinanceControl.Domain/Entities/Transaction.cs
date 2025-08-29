namespace FinanceControl.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public decimal Amount { get; private set; }
    public required string Category { get; set; }
    public DateTime Date { get; private set; }
    public string? Description { get; private set; }

    // Domain constructor - encapsulates business rules
    private Transaction() { } // For EF Core

    public static Transaction Create(decimal amount, string category, DateTime date, string? description = null)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount must be greater than zero", nameof(amount));
        
        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentException("Category is required", nameof(category));

        return new Transaction
        {
            Id = Guid.NewGuid(),
            Amount = amount,
            Category = category.Trim(),
            Date = date,
            Description = description?.Trim()
        };
    }

    // Domain methods
    public void UpdateAmount(decimal newAmount)
    {
        if (newAmount <= 0)
            throw new ArgumentException("Amount must be greater than zero", nameof(newAmount));
        
        Amount = newAmount;
    }

    public void UpdateCategory(string newCategory)
    {
        if (string.IsNullOrWhiteSpace(newCategory))
            throw new ArgumentException("Category is required", nameof(newCategory));
        
        Category = newCategory.Trim();
    }
}
