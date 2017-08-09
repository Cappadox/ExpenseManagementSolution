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
        private IExpenseRepository expenserepo;
        public ExpenseController(IExpenseItemRepository repo,IExpenseRepository repo2)
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
        public ActionResult List(ExpenseCart cart, string ViewModel)
        {
            var userId = User.Identity.GetUserId();
            var expense = cart.GetExpense();
            expense.UserId = userId;
            expense.DateOfExpense = DateTime.Now;
            expenserepo.AddExpense(expense);

            var items = cart.Lines;
            foreach (var item in items) {
                item.ExpenseId = expense.Id;
                repository.AddExpenseItem(item);
                    }
            return RedirectToAction("Index","Home");

        }
        public ActionResult AddExpense()
        {
            ExpenseFormViewModel ViewModel=new ExpenseFormViewModel();
            return View(ViewModel);
        }
        [HttpPost]
        [Authorize]
        public ActionResult AddExpense(ExpenseCart cart,ExpenseFormViewModel ViewModel)
        {
            var userId = User.Identity.GetUserId();

            VPExpenseItem item = new VPExpenseItem
            {
                Amount=ViewModel.Amount,
                DateOfExpense=ViewModel.GetDateTime(),
                UserId=userId,
                Description=ViewModel.Description

            };

            cart.AddItem(item);
              
            return RedirectToAction("Create","Expense");
        }

    }
}