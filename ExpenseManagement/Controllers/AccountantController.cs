using ExpenseManagement.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;
using ExpenseManagement.Persistence.Repositories;

namespace ExpenseManagement.Controllers
{
    [Authorize(Roles ="Accountant")]
    public class AccountantController : Controller
    {

        private IExpenseRepository repository;
        private IExpenseItemRepository itemrepo;
        private IExpenseHistoryRepository HistoryRepository;
        public AccountantController(IExpenseRepository expenserepo,IExpenseItemRepository expenseitemrepo,
            IExpenseHistoryRepository history)
        {
            repository = expenserepo;
            itemrepo = expenseitemrepo;
            HistoryRepository = history;

        }
        // GET: Accountant
        public ActionResult PendingExpenses()
        {
            var expenses = repository.GetExpensesNotPaid();
            var viewmodel = new List<ExpenseViewModel>();


            foreach (var item in expenses)
            {
                viewmodel.Add(new ExpenseViewModel()
                {
                    id = item.Id,
                    Description = item.Description,
                    Date = item.DateOfExpense,
                    Username = repository.GetUsername(item.UserId)                   
                });

            }
            return View(viewmodel);

         
        }
        public ActionResult Details(int id)
        {
            TempData["id"] = id;
            return View(itemrepo.GetExpenseItemsByExpenseId(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PayExpense(int id)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("PendingExpenses");
            }
            var expense = repository.GetExpense(id);
            int status = (expense.StatusId);
            var userId = User.Identity.GetUserId();

            HistoryRepository.UpdateExpenseHistoryPayment(status,userId);
            return RedirectToAction("Index", "Home");
        }
    }
}