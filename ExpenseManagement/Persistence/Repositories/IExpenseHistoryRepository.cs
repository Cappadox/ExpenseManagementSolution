using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Persistence.Repositories
{
    public interface IExpenseHistoryRepository
    {
        void AddExpenseHistory(VPExpenseHistory item);
        void RemoveExpenseHistory(VPExpenseHistory item);
        void UpdateExpenseHistory(int id);
        void UpdateExpenseHistoryPayment(int id, string userid);
    }
}