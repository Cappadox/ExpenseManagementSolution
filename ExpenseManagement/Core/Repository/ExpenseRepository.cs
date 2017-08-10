﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseManagement.Core.Models;
using Microsoft.Ajax.Utilities;

namespace ExpenseManagement.Core.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private ApplicationDbContext context;

        public ExpenseRepository(ApplicationDbContext _context)
        {
            context = _context;
        }

        public void AddExpense(VPExpense item)
        {
            context.Expense.Add(item);
            context.SaveChanges();
          
        }

        public void RemoveExpense(VPExpense item)
        {
            context.Expense.Remove(item);
        }

        public IEnumerable<VPExpense> GetExpenseItemsByUserId(string userId)
        {
            return context.Expense
                .Where(g =>
                    g.UserId == userId)
                .ToList();
        }

        public IEnumerable<VPExpense> GetExpenses()
        {
            return context.Expense.ToList();
        }

        public string GetUsername(string userid)
        {
            ApplicationUser currentUser = context.Users.FirstOrDefault(x =>x.Id==userid);
            if (currentUser.Id != null)
            {
                return currentUser.UserName;
            }

            else
                return "no user";
        }

       
       
    }
}