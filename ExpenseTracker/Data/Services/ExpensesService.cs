using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data.Services
{
    public class ExpensesService
    {
         
        private readonly ExpenseAppContext _context;
        public ExpensesService(ExpenseAppContext context)
        {
            _context = context;
        }

        public async Task Add(Expense expence)
        {
            _context.Expenses.Add(expence);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expences = await _context.Expenses.ToListAsync();
            return expences;
        }

        public IQueryable GetChartData()
        {
            var data = _context.Expenses
                .GroupBy(e => e.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(e => e.Amount)

                });
            return data;
        }
        public async Task<Expense> GetById(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }


        public async Task Update(Expense expence)
        {
            _context.Update(expence);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var expence = await _context.Expenses.FindAsync(id);
            if (expence != null)
            {
                _context.Expenses.Remove(expence);
                await _context.SaveChangesAsync();
            }
        }

    }
}
    

