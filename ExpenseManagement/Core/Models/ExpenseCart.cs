using ExpenseManagement.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseManagement.Core.Models
{
    public class ExpenseCart
    {
        private List<VPExpenseItem> lineCollection = new List<VPExpenseItem>();
        private VPExpense expense;
        public ExpenseCart()
        {
            expense = new VPExpense();
        }

        public void AddItem(VPExpenseItem product)
        {
            
            VPExpenseItem line = lineCollection
                .Where(p => p.Id == product.Id)
                .FirstOrDefault();
            lineCollection.Add(product);
            expense.ExpenseItems.Add(product);
        }

        public VPExpense GetExpense()
        {
            return expense;
        }

        public void RemoveLine(VPExpenseItem product)
        {
            lineCollection.RemoveAll(l => l.Id == product.Id);
        }

        public float ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Amount);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<VPExpenseItem> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public VPExpenseItem Expenseitem { get; set; }
    }

}
