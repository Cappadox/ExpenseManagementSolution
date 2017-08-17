using System;
using System.Web.Mvc;
using ExpenseManagement.Core.ViewModels;
using Microsoft.AspNet.Identity;
using ExpenseManagement.Core.Models;
using ExpenseManagement.Core.Repository;
using System.Web.Security;
using ExpenseManagement.Persistence.Repositories;

namespace ExpenseManagement.Controllers
{
    [Authorize(Roles = "Employee")]
    public class ExpenseController : Controller
    {
        private ApplicationDbContext _Context;
        private IExpenseItemRepository repository;
        private IExpenseRepository expenserepo;
        public ExpenseController(IExpenseItemRepository repo, IExpenseRepository repo2,
            IExpenseItemRepository repo3)
        {
            repository = repo3;
            expenserepo = repo2;
            repository = repo;
        }
        // GET: Expense
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Notifications()
        {
            var userId = User.Identity.GetUserId();

            var viewmodel=expenserepo.GetReturnedExpenses(userId);

            return View(viewmodel);
        }

        public ActionResult EditExpense(int id)
        {
            var model = repository.GetExpenseItem(id);
            return View(model);

        }
        [HttpPost]
        public ActionResult EditExpense(VPExpenseItem viewModel)
        {
           
           repository.UpdateExpenseItem(viewModel);

            return RedirectToAction("Index","Home");

        }
        public ViewResult List(ExpenseCart cart)
        {
            return View(new ExpenseCartViewModel()
            {
                Cart = cart,
            });

        }
        [HttpPost]
        public ActionResult List(ExpenseCart cart, string description)
        {
            var userId = User.Identity.GetUserId();
           
            var expense = cart.GetExpense();
            expense.UserId = userId;
            expense.ModifyBy = User.Identity.GetUserName();
            expense.ExpenseDate=DateTime.Now;
            expense.Description = description;
            expense.ModifyBy = User.Identity.GetUserName();
            expense.Status=Status.WaitingApprove;

            VPExpenseHistory history = new VPExpenseHistory
            {
                ModifyBy = User.Identity.GetUserName(),

            };
            //expense.ExpenseHistory = history;
            expenserepo.AddExpense(expense);

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Details(int id)
        {
            var model=repository.GetExpenseItemsByExpenseId(id);
            return View(model);
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
                ExpenseDate = ViewModel.GetDateTime(),
                UserId = userId,
                Description = ViewModel.Description

            };

            cart.AddItem(item);

            return RedirectToAction("Create", "Expense");
        }

    }
}