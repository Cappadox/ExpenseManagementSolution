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
            expense.ModifyDate = DateTime.Now;
            expense.IsApproved = true;
            context.SaveChanges();
        }

        public void UpdateExpenseHistoryPayment(int id,string userid)
        {
            var expense = context.ExpenseHistory.FirstOrDefault(a => a.Id == id);
            var user = context.Users.FirstOrDefault(a => a.Id == userid);
            expense.DateOfPayment = DateTime.Now;
            expense.IsPaid = true;
            expense.ModifyBy = user.UserName;
            context.SaveChanges();
        }
    }
}