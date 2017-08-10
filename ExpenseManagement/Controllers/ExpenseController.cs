using System;
using System.Web.Mvc;
using ExpenseManagement.Core.ViewModels;
using Microsoft.AspNet.Identity;
using ExpenseManagement.Core.Models;
using ExpenseManagement.Core.Repository;
using System.Web.Security;

namespace ExpenseManagement.Controllers
{
    [Authorize(Roles = "Employee")]
    public class ExpenseController : Controller
    {
        private ApplicationDbContext _Context;
        private IExpenseItemRepository repository;
        private IExpenseRepository expenserepo;
        public ExpenseController(IExpenseItemRepository repo, IExpenseRepository repo2)
        {
            expenserepo = repo2;
            repository = repo;
        }
        // GET: Expense
        public ActionResult Create()
        {
            return View();
        }


        public ViewResult List(ExpenseCart cart)
        {
            var userId = User.Identity.GetUserId();

            var items = cart.Lines;

            return View(items);

        }
        [HttpPost]
        public ActionResult List(ExpenseCart cart, string description)
        {
            var userId = User.Identity.GetUserId();
            var expense = cart.GetExpense();
            expense.UserId = userId;
            expense.DateOfExpense = DateTime.Now;
            expense.Description = description;
            expense.ModifyBy = User.Identity.GetUserName();
            expense.ModifyDate = DateTime.Now;

            VPExpenseHistory history = new VPExpenseHistory
            {
                ModifyBy = User.Identity.GetUserName(),

            };
            expense.ExpenseHistory = history;
            expenserepo.AddExpense(expense);

            return RedirectToAction("Index", "Home");

        }
        public ActionResult AddExpense()
        {
            ExpenseFormViewModel ViewModel = new ExpenseFormViewModel();
            return View(ViewModel);
        }

        [HttpPost, Authorize(Roles = "Employee"), ValidateAntiForgeryToken]
        public ActionResult AddExpense(ExpenseCart cart, ExpenseFormViewModel ViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View("AddExpense", ViewModel);

            }

            var userId = User.Identity.GetUserId();

            VPExpenseHistory history = new VPExpenseHistory
            {
                ModifyBy = User.Identity.GetUserName(),

            };

            VPExpenseItem item = new VPExpenseItem
            {
                Amount = ViewModel.Amount,
                DateOfExpense = ViewModel.GetDateTime(),
                UserId = userId,
                Description = ViewModel.Description

            };

            cart.AddItem(item);

            return RedirectToAction("Create", "Expense");
        }

    }
}