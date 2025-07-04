using ExpenseTracker.Data;
using ExpenseTracker.Data.Services;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }
        public async Task<IActionResult> Index()
        {
            var expenses = await _expensesService.GetAll();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expensesService.Add(expense);
                return RedirectToAction("Index");
            }
            return View(expense);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var expense = await _expensesService.GetById(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        public ActionResult GetChart()
        {
            var chartData = _expensesService.GetChartData();
            return Json(chartData);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id  ,Expense expense)
        {
            if (id !=expense.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _expensesService.Update(expense);
                    return RedirectToAction("Index");
                }
                catch
                {
                    if (await _expensesService.GetById(id) == null)
                    {
                        return NotFound();
                    }
                    throw;

                }
                
            }
            return View(expense);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var expense = await _expensesService.GetById(id);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _expensesService.Delete(id);
            return RedirectToAction("Index");
        }
    }


}
