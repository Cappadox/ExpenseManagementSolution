using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using ExpenseManagement.Core.Models;
using Microsoft.Ajax.Utilities;

namespace ExpenseManagement.Core.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private ApplicationDbContext context;

        public ExpenseRepository()
        {
            context = new ApplicationDbContext();
        }

        public void AddExpense(VPExpense item)
        {
            context.Expense.Add(item);
            context.SaveChanges();
          
        }

        public void RemoveExpense(VPExpense item)
        {
            try
            {
                context.Expense.Remove(item);
            }

            catch (Exception ex)
            {
              // TODO log this error
                
            }

        }

        public IEnumerable<VPExpense> GetExpenseItemsByUserId(string userId)
        {
            return context.Expense
                .Where(g =>
                    g.UserId == userId)
                .ToList();
        }

        public IEnumerable<VPExpense> GetExpensesNotApproved()
        {
            return context.Expense.Where(a=>a.ExpenseHistory.IsApproved==false).ToList();
        }

        public IEnumerable<VPExpense> GetExpensesNotPaid()
        {
            return context.Expense.Where(a => a.ExpenseHistory.IsPaid == false).ToList();
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

        public VPExpenseHistory GetExpenseHistory(int id)
        {
            var expense = context.Expense.FirstOrDefault(a => a.Id == id);
            
            return expense.ExpenseHistory;
        }

        public void UpdateExpenseHistory(int id,VPExpenseHistory history)
        {
            var expense = context.Expense.FirstOrDefault(a => a.Id == id);
            expense.ExpenseHistory = history;
            context.Expense.AddOrUpdate(expense);
        }

        public VPExpense GetExpense(int id)
        {
            return context.Expense.FirstOrDefault(a => a.Id == id);
        }

        public void RejectionExpense(int id, string comment)
        {
            var expense = context.Expense.FirstOrDefault(a => a.Id == id);
            expense.RejectionComment = comment;
            context.SaveChanges();

        }

        public IEnumerable<VPExpense> GetReturnedExpenses(string userid)
        {
           return context.Expense.Where(a => a.UserId == userid && a.RejectionComment != null);


        }

    }
}