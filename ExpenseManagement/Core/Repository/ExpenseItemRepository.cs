using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using ExpenseManagement.Core.Models;
using ExpenseManagement.Persistence.Repositories;

namespace ExpenseManagement.Core.Repository
{
    public class ExpenseItemRepository:IExpenseItemRepository
    {
        private readonly ApplicationDbContext _Context;

        public ExpenseItemRepository()
        {
                _Context=new ApplicationDbContext();
        }

        public void AddExpenseItem(VPExpenseItem item)
        {
            _Context.ExpenseItem.Add(item);
            _Context.SaveChanges();
        }
        public void RemoveExpenseItem(VPExpenseItem item)
        {
            _Context.ExpenseItem.Remove(item);
        }

        public IEnumerable<VPExpenseItem> GetExpenseItemsByUserId(string userId)
        {
             return _Context.ExpenseItem
                .Where(g =>
                    g.UserId == userId)
                .ToList();

        }

        public VPExpenseItem GetExpenseItem(int id)
        {
            return _Context.ExpenseItem.FirstOrDefault(a=>a.Id==id);
        }

        public IEnumerable<VPExpenseItem> GetExpenseItemsByExpenseId(int expenseid)
        {
            return _Context.ExpenseItem
                .Where(g =>
                    g.ExpenseId == expenseid)
                .ToList();

        }

       public void UpdateExpenseItem(VPExpenseItem item)
        {
 
            var expenseitem = _Context.ExpenseItem.FirstOrDefault(a => a.Id == item.Id);
            expenseitem.Amount = item.Amount;
            expenseitem.ExpenseDate = item.ExpenseDate;
            expenseitem.Description = item.Description;
            _Context.SaveChanges();
        }
    }
}