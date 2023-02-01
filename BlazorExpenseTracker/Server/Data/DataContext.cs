using BlazorExpenseTracker.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorExpenseTracker.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseModel>().HasData
            (
                new ExpenseModel()
                {
                    Id = 1,
                    Title = "Bought a Snack",
                    Description = "",
                    Amount = 10.0M,
                    CreatedAt = DateTime.UtcNow

                },
                new ExpenseModel()
                {
                    Id = 2,
                    Title = "Bought a phone",
                    Description = "",
                    Amount = 100.0M,
                    CreatedAt = DateTime.UtcNow.AddHours(1)
                }
                , new ExpenseModel()
                {
                    Id = 3,
                    Title = "Bought Lunch",
                    Description = "",
                    Amount = 0.0M,
                    CreatedAt = DateTime.UtcNow.AddHours(2)
                }
            );
        }
        public DbSet<ExpenseModel> Expenses { get; set; }
    }
   
}
