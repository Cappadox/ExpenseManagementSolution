using ExpenseManagement.Migrations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement.Core.Models
{
    public class VPExpenseItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Nullable<DateTime> ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public Nullable<DateTime> ExpenseDate { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public int ExpenseId { get; set; }

        [ForeignKey("ExpenseId")]
        public VPExpense Expense { get; set; }


    }
}