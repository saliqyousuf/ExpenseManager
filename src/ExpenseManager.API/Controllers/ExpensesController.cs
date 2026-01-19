using ExpenseManager.Application.Services;
using ExpenseManager.Core.Models;

using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly ExpenseService _service;

    public ExpensesController(ExpenseService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var item = await _service.GetAsync(id);
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Expense expense)
    {
        await _service.AddAsync(expense);
        return CreatedAtAction(nameof(Get), new { id = expense.Id }, expense);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Expense expense)
    {
        expense.Id = id;
        await _service.UpdateAsync(expense);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}