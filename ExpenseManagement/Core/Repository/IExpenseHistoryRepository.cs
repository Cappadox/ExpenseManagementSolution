using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Core.Repository
{
    public interface IExpenseHistoryRepository
    {
        void AddExpenseHistory(VPExpenseHistory item);
        void RemoveExpenseHistory(VPExpenseHistory item);
        void UpdateExpenseHistory(int id);
    }
}