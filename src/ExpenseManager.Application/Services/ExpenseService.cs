using ExpenseManager.Core.Interfaces;
using ExpenseManager.Core.Models;

namespace ExpenseManager.Application.Services;

public class ExpenseService
{
    private readonly IExpenseRepository _repo;

    public ExpenseService(IExpenseRepository repo)
    {
        _repo = repo;
    }

    public Task<Expense> GetAsync(Guid id) => _repo.GetByIdAsync(id);
    public Task<IEnumerable<Expense>> GetAllAsync() => _repo.GetAllAsync();
    public Task AddAsync(Expense expense) => _repo.AddAsync(expense);
    public Task UpdateAsync(Expense expense) => _repo.UpdateAsync(expense);
    public Task DeleteAsync(Guid id) => _repo.DeleteAsync(id);
}