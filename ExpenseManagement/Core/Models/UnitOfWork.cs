using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseManagement.Core.Models
{
    public class UnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}