using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement.Core.Models
{
    public class VPExpenseHistory
    {
       
        public int Id { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        //public DateTime? DateOfApproval { get; set; }
        //public DateTime? DateOfPayment { get; set; }

        public int ExpenseId { get; set; }

        [ForeignKey("ExpenseId")]
        public VPExpense Expense { get; set; }
    }
}