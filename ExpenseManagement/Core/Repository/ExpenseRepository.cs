﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Core.Repository
{
    public class ExpenseRepository
    {
        private ApplicationDbContext context;

        public ExpenseRepository()
        {
            context=new ApplicationDbContext();
        }

        public void AddExpense(VPExpense item)
        {
            context.Expense.Add(item);
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

    }
}