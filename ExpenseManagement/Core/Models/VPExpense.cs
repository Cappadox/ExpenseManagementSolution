using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        public string UserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? DateOfExpense { get; set; }
        public string RejectionComment { get; set; }
        public string Description { get; set; }
        public ICollection<VPExpenseItem> ExpenseItems { get; set; }

        public int? StatusId { get; set; }

        [ForeignKey("StatusId")]
        public VPExpenseHistory ExpenseHistory { get; set; }

    }
}