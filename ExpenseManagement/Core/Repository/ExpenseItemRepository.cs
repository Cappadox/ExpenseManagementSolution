using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Core.Repository
{
    public class ExpenseItemRepository
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


    }
}