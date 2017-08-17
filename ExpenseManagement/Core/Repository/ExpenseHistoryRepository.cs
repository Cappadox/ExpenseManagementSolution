using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseManagement.Core.Models;
using ExpenseManagement.Persistence.Repositories;
using Microsoft.AspNet.Identity;


namespace ExpenseManagement.Core.Repository
{
    public class ExpenseHistoryRepository : IExpenseHistoryRepository
    {
        private ApplicationDbContext context;

        public ExpenseHistoryRepository()
        {
            context = new ApplicationDbContext();
        }

        public void AddExpenseHistory(int id,string username)
        {

          
            context.ExpenseHistory.Add(new VPExpenseHistory()
            {
               ExpenseId = id,
               ModifyDate = DateTime.Now,
               ModifyBy = username

        });
            context.SaveChanges();

        }

        public void RemoveExpenseHistory(VPExpenseHistory item)
        {
            context.ExpenseHistory.Remove(item);

        }

        public void UpdateExpenseHistory(int id)
        {
          
            var expense = context.ExpenseHistory.FirstOrDefault(a => a.Id == id);
            expense.ModifyDate = DateTime.Now;
            context.SaveChanges();
        }

        public void UpdateExpenseHistoryPayment(int id,string userid)
        {
            var expense = context.ExpenseHistory.FirstOrDefault(a => a.Id == id);
            var user = context.Users.FirstOrDefault(a => a.Id == userid);
          
            expense.ModifyBy = user.UserName;
            context.SaveChanges();
        }
    }
}