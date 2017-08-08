using System.Data.Entity;

namespace ExpenseManagement.Core.Models
{
    public interface IApplicationDbContext
    {
        DbSet<VPExpense> Expense { get; set; }
        DbSet<VPExpenseHistory> ExpenseHistory { get; set; }
        DbSet<VPExpenseItem> ExpenseItem { get; set; }
    }
}