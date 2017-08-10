using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.Core.Repository;
using ExpenseManagement.Core.ViewModels;

namespace ExpenseManagement.Controllers
{
    public class ManagerController : Controller
    {
        private IExpenseRepository repository;

        public ManagerController(IExpenseRepository repo)
        {
            repository = repo;
        }
        // GET: Manager
        [Authorize(Roles = "Manager")]
        public ActionResult ExpenseList()
        {
            return View(repository.GetExpenses());
        }
    }
}