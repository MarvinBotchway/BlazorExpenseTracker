using BlazorExpenseTracker.Server.Data;
using BlazorExpenseTracker.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorExpenseTracker.Server.Services.ExpenseService
{
    public class ExpenseService : IExpenseService
    {
        private readonly DataContext _context;

        public ExpenseService(DataContext context)
        {
            _context = context;
        }


        public async Task<ExpenseModel> CreateExpensesAsync(ExpenseModel expense)
        {
            var response = await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return response.Entity;
            
        }

        public async Task<ExpenseModel> EditExpenseAsync(ExpenseModel expense, int id)
        {
            ExpenseModel response = null;
            var DbExpense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);

            if (DbExpense != null)
            {
                DbExpense.Amount = expense.Amount;
                DbExpense.Title = expense.Title;
                DbExpense.Description = expense.Description;
                DbExpense.CreatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                response = DbExpense;
            }

            return response;
        }

        public async Task<List<ExpenseModel>> GetExpensesAsync()
        {
            var response = await _context.Expenses.ToListAsync();

            return response;
        }

        public async Task RemoveExpense(int id)
        {
            var DbExpense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);
            if (DbExpense != null)
            {
                _context.Expenses.Remove(DbExpense);
            }

            await _context.SaveChangesAsync();
        }
    }
}
