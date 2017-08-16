using System.Collections.Generic;
using System.Web.Mvc;
using ExpenseManagement.Core.ViewModels;
using ExpenseManagement.Persistence.Repositories;

namespace ExpenseManagement.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private IExpenseRepository repository;
        private IExpenseItemRepository itemrepo;
        private IExpenseHistoryRepository HistoryRepository;

        public ManagerController(IExpenseRepository repo, IExpenseItemRepository item,
            IExpenseHistoryRepository historyrepo)
        {
            HistoryRepository = historyrepo;
            repository = repo;
            itemrepo = item;
        }
        // GET: Manager
        
        public ActionResult ExpenseList()
        {
            var expenses = repository.GetExpensesNotApproved();
            var viewmodel = new List<ExpenseViewModel>();
           
            
            foreach (var item in expenses)
            {
                viewmodel.Add(new ExpenseViewModel()
                {
                    id=item.Id,
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
        public ActionResult SendExpense(int id)
        {
        var expense=repository.GetExpense(id);
            int status = (expense.StatusId);
          HistoryRepository.UpdateExpenseHistory(status);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Reject(int id,string rejectioncomment)
        {
          
            repository.RejectionExpense(id, rejectioncomment);
            return RedirectToAction("Index", "Home");
        }
    }
}