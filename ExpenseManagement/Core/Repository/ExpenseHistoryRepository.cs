using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Core.Repository
{
    public class ExpenseHistoryRepository : IExpenseHistoryRepository
    {
        private ApplicationDbContext context;

        public ExpenseHistoryRepository()
        {
            context = new ApplicationDbContext();
        }

        public void AddExpenseHistory(VPExpenseHistory item)
        {
            context.ExpenseHistory.Add(item);
            
        }

        public void RemoveExpenseHistory(VPExpenseHistory item)
        {
            context.ExpenseHistory.Remove(item);

        }

        public void UpdateExpenseHistory(int id)
        {
            var expense = context.ExpenseHistory.FirstOrDefault(a => a.Id == id);
            expense.DateOfApproval=DateTime.Now;
            expense.IsApproved = true;
            context.ExpenseHistory.Add(expense);
            context.SaveChanges();
        }

    }
}