using ExpenseTracker.Models;

namespace ExpenseTracker.Data.Services
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAll();
        Task Add(Expense expence);
        IQueryable GetChartData();
        Task<Expense> GetById(int id);
        Task Update(Expense expence);
        Task Delete(int id);
    }
}
