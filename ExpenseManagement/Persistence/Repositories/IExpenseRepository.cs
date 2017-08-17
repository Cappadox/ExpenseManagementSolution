using System.Collections.Generic;
using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Persistence.Repositories
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
        void RejectionExpense(int id, string comment);
        IEnumerable<VPExpense> GetReturnedExpenses(string userid);
        void UpdateStatus(int id);
        void UpdateStatusPayment(int id);
    }
}