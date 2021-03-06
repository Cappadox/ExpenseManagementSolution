﻿using System.Collections.Generic;
using System.Web.Mvc;
using ExpenseManagement.Core.ViewModels;
using ExpenseManagement.Persistence.Repositories;
using Microsoft.AspNet.Identity;

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
                    Date = item.ExpenseDate,
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
            string username=User.Identity.GetUserName();
          HistoryRepository.AddExpenseHistory(id,username);
            repository.UpdateStatus(id);
            return RedirectToAction("ExpenseList", "Manager");
        }

        [HttpPost]
        public ActionResult Reject(int id,string rejectioncomment)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ExpenseList", "Manager");

            }
            string username = User.Identity.GetUserName();
            repository.UpdateStatus(id);
            HistoryRepository.AddExpenseHistory(id, username);
            repository.RejectionExpense(id, rejectioncomment);
            return RedirectToAction("Index", "Home");
        }
    }
}