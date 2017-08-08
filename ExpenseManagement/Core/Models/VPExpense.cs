using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseManagement.Core.Models
{
    public class VPExpense
    {
        public VPExpense()
        {
            ExpenseItems = new Collection<VPExpenseItem>();
        }
        [Key]
        public int Id { get; set; }
        public ApplicationUser Users { get; set; }
        [Required]
        public string UserId { get; set; }
        DateTime ModifyDate { get; set; }
        string ModifyBy { get; set; }
        int StatusId { get; set; }
        public DateTime? DateOfExpense { get; set; }
        string RejectionComment { get; set; }
        string Description { get; set; }
        public ICollection<VPExpenseItem> ExpenseItems { get; set; }
        public VPExpenseHistory ExpenseHistory { get; set; }

    }
}