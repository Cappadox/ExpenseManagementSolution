using System;

namespace ExpenseManagement.Core.Models
{
    public class VPExpenseItem
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        //DateTime ModifyDate { get; set; }
        //string ModifyBy { get; set; }
        public DateTime DateOfExpense { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        //public int ExpenseId { get; set; }
        //public VPExpense Expense { get; set; }


    }
}