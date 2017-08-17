using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Persistence.Repositories
{
    public interface IExpenseHistoryRepository
    {
        void AddExpenseHistory(int id, string username);
        void RemoveExpenseHistory(VPExpenseHistory item);
        void UpdateExpenseHistory(int id);
        void UpdateExpenseHistoryPayment(int id, string userid);
    }
}