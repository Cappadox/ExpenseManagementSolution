using ExpenseManagement.Core.Models;

namespace ExpenseManagement.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = { "Manager", "Accountant", "Employee" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                if (!RoleManager.RoleExists(roleName))
                {
                    roleResult = RoleManager.Create(new IdentityRole(roleName));
                }
            }
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            if (!(context.Users.Any(u => u.UserName == "manager@example.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { Email = "manager@example.com", PhoneNumber = "0797697898", UserName = "manager@example.com" };
                userManager.Create(userToInsert, "Password@123");
                UserManager.AddToRole(userToInsert.Id, "Manager");

            }

            if (!(context.Users.Any(u => u.UserName == "accountant@example.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { Email = "accountant@example.com", PhoneNumber = "0797697898", UserName = "accountant@example.com" };
                userManager.Create(userToInsert, "Password@123");
                UserManager.AddToRole(userToInsert.Id, "Accountant");

            }

            if (!(context.Users.Any(u => u.UserName == "employee@example.com")))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                ApplicationUser currentUser = context.Users.FirstOrDefault(x =>x.Email=="manager@example.com");
                var userToInsert = new ApplicationUser { Email = "employee@example.com", PhoneNumber = "0797697898", UserName = "employee@example.com", SuperVisorId=currentUser.Id };
                userManager.Create(userToInsert, "Password@123");
                UserManager.AddToRole(userToInsert.Id, "Employee");

            }
        }
    }
}
