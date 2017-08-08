using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.Core.ViewModels;
using Microsoft.AspNet.Identity;
using ExpenseManagement.Core.Models;
using ExpenseManagement.Core.Repository;

namespace ExpenseManagement.Controllers
{
    public class ExpenseController : Controller
    {
        private ApplicationDbContext _Context;
        private IExpenseItemRepository repository;
        private ExpenseRepository expenserepo;
        public ExpenseController(IExpenseItemRepository repo)
        {

            repository = repo;
        }
        // GET: Expense
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();

            var items = repository.GetExpenseItemsByUserId(userId);

            return View(items);

        }
        public ActionResult AddExpense()
        {
            ExpenseFormViewModel ViewModel=new ExpenseFormViewModel();
            return View(ViewModel);
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddExpense(ExpenseFormViewModel ViewModel)
        {


            var userId = User.Identity.GetUserId();

            VPExpenseItem item = new VPExpenseItem
            {
                UserId = userId,
                Amount = ViewModel.Amount,
                DateOfExpense = ViewModel.GetDateTime(),
                Description = ViewModel.Description,
            };
        
            repository.AddExpenseItem(item);
            return RedirectToAction("Create","Expense");
        }
    }
}