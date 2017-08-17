using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ExpenseManagement.Core.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> , IApplicationDbContext
    {
        public DbSet<VPExpense>Expense { get; set; }
        public DbSet<VPExpenseItem> ExpenseItem { get; set; }
        public DbSet<VPExpenseHistory> ExpenseHistory { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<VPExpenseHistory>()
        //        .HasRequired<VPExpense>(p => p.Expense)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);

        //    //player - club team relations    
        //}

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}