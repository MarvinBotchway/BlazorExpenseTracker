using BlazorExpenseTracker.Server.Data;
using BlazorExpenseTracker.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorExpenseTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly DataContext _context;

        public ExpensesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExpenseModel>>> GetAllExpensesAsync()
        {
            var response = await _context.Expenses.ToListAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ExpenseModel>> CreateExpenseAsync(ExpenseModel expense)
        {
            var response = await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return Ok(response.Entity);

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ExpenseModel>> EditExpenseAsync(ExpenseModel expense, int id)
        {
            ExpenseModel? response = null;
            var DbExpense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == id);

            if (DbExpense != null)
            {
                DbExpense.Title = expense.Title;
                DbExpense.Description = expense.Description;
                DbExpense.Amount = expense.Amount;
                DbExpense.CreatedAt = expense.CreatedAt;

                await _context.SaveChangesAsync();

                response = DbExpense;

            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task RemoveExpense(int id)
        {
            var DbExpense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id==id);

            if (DbExpense != null )
            {
                _context.Expenses.Remove(DbExpense);
            }

            await _context.SaveChangesAsync();
        }
    }
}
