using System.Collections.Generic;
using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Persistence.Repositories
{
    public interface IExpenseItemRepository
    {
        void AddExpenseItem(VPExpenseItem item);
        IEnumerable<VPExpenseItem> GetExpenseItemsByUserId(string userId);
        void RemoveExpenseItem(VPExpenseItem item);
        IEnumerable<VPExpenseItem> GetExpenseItemsByExpenseId(int expenseid);
        VPExpenseItem GetExpenseItem(int id);
        void UpdateExpenseItem(VPExpenseItem item);
    }
}