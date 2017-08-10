using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpenseManagement.Core.ViewModels
{
    public class ExpenseFormViewModel
    {
        public int Expenseid { get; set; }
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0}", Date));
        }
    }
}