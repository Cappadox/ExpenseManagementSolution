using System;
using System.Collections.Generic;
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
        private ExpenseItemRepository repo;

        public ExpenseController()
        {
                    repo=new ExpenseItemRepository();
                _Context=new ApplicationDbContext();
        }
        // GET: Expense
        public ActionResult Create()
        {   
            return View();
        }


        public ActionResult AddExpense()
        {
            ExpenseFormViewModel ViewModel=new ExpenseFormViewModel();
            return View(ViewModel);
        }
        [HttpPost]
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

            repo.AddExpenseItem(item);
            return RedirectToAction("Create","Expense");
        }
    }
}