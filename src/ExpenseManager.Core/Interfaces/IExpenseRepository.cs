using ExpenseManager.Core.Models;

namespace ExpenseManager.Core.Interfaces;

public interface IExpenseRepository
{
    Task<Expense> GetByIdAsync(Guid id);
    Task<IEnumerable<Expense>> GetAllAsync();
    Task AddAsync(Expense expense);
    Task UpdateAsync(Expense expense);
    Task DeleteAsync(Guid id);
}