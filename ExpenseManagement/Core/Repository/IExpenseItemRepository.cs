using System.Collections.Generic;
using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Core.Repository
{
    public interface IExpenseItemRepository
    {
        void AddExpenseItem(VPExpenseItem item);
        IEnumerable<VPExpenseItem> GetExpenseItemsByUserId(string userId);
        void RemoveExpenseItem(VPExpenseItem item);
       IEnumerable<VPExpenseItem> GetExpenseItemsByExpenseId(int expenseid);
    }
}