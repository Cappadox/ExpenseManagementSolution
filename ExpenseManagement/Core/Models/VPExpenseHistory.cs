using System;

namespace ExpenseManagement.Core.Models
{
    public class VPExpenseHistory
    {
        public int Id { get; set; }
        public bool IsPaid { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime DateOfApproval { get; set; }
        public DateTime DateOfPayment { get; set; }
    }
}