using ExpenseManager.Core.Interfaces;
using ExpenseManager.Core.Models;

namespace ExpenseManager.Infrastructure.Repositories;

public class InMemoryExpenseRepository : IExpenseRepository
{
    private readonly List<Expense> _items = new();

    public Task AddAsync(Expense expense)
    {
        expense.Id = Guid.NewGuid();
        _items.Add(expense);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id)
    {
        _items.RemoveAll(x => x.Id == id);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Expense>> GetAllAsync()
    {
        return Task.FromResult(_items.AsEnumerable());
    }

    public Task<Expense> GetByIdAsync(Guid id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id) ?? throw new KeyNotFoundException();
        return Task.FromResult(item);
    }

    public Task UpdateAsync(Expense expense)
    {
        var idx = _items.FindIndex(x => x.Id == expense.Id);
        if (idx >= 0)
            _items[idx] = expense;
        return Task.CompletedTask;
    }
}