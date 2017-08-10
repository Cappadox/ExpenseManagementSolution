using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Core.ViewModels
{
    public class ExpenseViewModel
    {
        public int id { get; set; }
        public DateTime? Date { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0}", Date));
        }
            public string Username { get; set; }
            public float TotalAmount { get; set; }

    }
}