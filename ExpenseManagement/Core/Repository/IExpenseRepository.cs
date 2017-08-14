using System.Collections.Generic;
using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Core.Repository
{
    public interface IExpenseRepository
    {
        void AddExpense(VPExpense item);
        IEnumerable<VPExpense> GetExpenseItemsByUserId(string userId);
        void RemoveExpense(VPExpense item);
        string GetUsername(string userid);
        VPExpenseHistory GetExpenseHistory(int id);
        void UpdateExpenseHistory(int id, VPExpenseHistory history);
         VPExpense GetExpense(int id);
        IEnumerable<VPExpense> GetExpensesNotApproved();
        IEnumerable<VPExpense> GetExpensesNotPaid();
    }
}