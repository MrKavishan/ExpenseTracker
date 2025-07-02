using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Data
{
    public class ExpenseAppContext :DbContext
    {
        public ExpenseAppContext(DbContextOptions<ExpenseAppContext>options) : base(options)
        {

        }
        public DbSet<Expence> Expences { get; set; } 

    }
}
