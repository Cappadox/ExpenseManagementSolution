using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement.Core.Models
{
    public enum Status
    {
        Draft = 0,
        WaitingApprove = 1,
        WaitingPayment = 2,
        Rejected = 3,
        Paid = 4
    };
    public class VPExpense
    {
        public VPExpense()
        {
            ExpenseItems = new Collection<VPExpenseItem>();
            IsDelete = false;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string RejectionComment { get; set; }
        public string Description { get; set; }
        public ICollection<VPExpenseItem> ExpenseItems { get; set; }
        public Status Status { get; set; }
        public bool IsDelete { get; set; }

    }
}

