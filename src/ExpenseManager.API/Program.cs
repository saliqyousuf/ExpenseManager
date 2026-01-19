using ExpenseManager.Infrastructure.Repositories;
using ExpenseManager.Application.Services;
using ExpenseManager.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IExpenseRepository, InMemoryExpenseRepository>();
builder.Services.AddScoped<ExpenseService>();

builder.Services.AddControllers();
var app = builder.Build();

app.MapControllers();

app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();