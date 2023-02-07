﻿using BlazorExpenseTracker.Shared.Models;

namespace BlazorExpenseTracker.Server.Services.ExpenseService
{
    public interface IExpenseService
    {

        Task<List<ExpenseModel>> GetExpensesAsync();
        Task<ExpenseModel> CreateExpensesAsync(ExpenseModel expense);
        Task<ExpenseModel> EditExpenseAsync(ExpenseModel expense, int id);
        Task RemoveExpense(int id);

    }
}
