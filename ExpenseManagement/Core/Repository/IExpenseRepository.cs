using System.Collections.Generic;
using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Core.Repository
{
    public interface IExpenseRepository
    {
        void AddExpense(VPExpense item);
        IEnumerable<VPExpense> GetExpenseItemsByUserId(string userId);
        void RemoveExpense(VPExpense item);
        IEnumerable<VPExpense> GetExpenses();
    }
}