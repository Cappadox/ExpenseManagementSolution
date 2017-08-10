using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.Core.Models;
using ExpenseManagement.Core.Repository;
using ExpenseManagement.Core.ViewModels;

namespace ExpenseManagement.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private IExpenseRepository repository;
        private IExpenseItemRepository itemrepo;
        private IExpenseHistoryRepository HistoryRepository;

        public ManagerController(IExpenseRepository repo, IExpenseItemRepository item,IExpenseHistoryRepository historyrepo)
        {
            HistoryRepository = historyrepo;
            repository = repo;
            itemrepo = item;
        }
        // GET: Manager
        
        public ActionResult ExpenseList()
        {
            var expenses = repository.GetExpenses();
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
       
        public ActionResult SendExpense(int id)
        {
        var expense=repository.GetExpense(id);
            int status = (expense.StatusId);
          HistoryRepository.UpdateExpenseHistory(id);
            return RedirectToAction("Index", "Home");
        }
    }
}