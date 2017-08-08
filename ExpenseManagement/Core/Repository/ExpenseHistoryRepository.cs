using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Core.Repository
{
    public class ExpenseHistoryRepository
    {
        private IApplicationDbContext context;

        public ExpenseHistoryRepository(IApplicationDbContext _context)
        {
            context = _context;
        }

        public void AddExpenseHistory(VPExpenseHistory item)
        {
            context.ExpenseHistory.Add(item);

        }

        public void RemoveExpenseHistory(VPExpenseHistory item)
        {
            context.ExpenseHistory.Remove(item);

        }

    }
}