using ExpenseManagement.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity.Owin;

namespace ExpenseManagement.Controllers
{
    public class NavController : Controller
    {
        private readonly ApplicationDbContext context;

        public NavController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Nav
        [ChildActionOnly]
        public ActionResult Menu()
        {
            var userId = User.Identity.GetUserId();
            if (userId != null)
            {
                ApplicationUserManager UserManager =
                    HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var roles = UserManager.GetRoles(userId);

                if (roles.Contains("Manager"))

                {
                    return PartialView("_NavigationManager");

                }
                if (roles.Contains("Accountant"))

                {
                    return PartialView("_NavigationAccountant");

                }

                 if (roles.Contains("Employee"))

                {
                    return PartialView("_NavigationEmployee");

                }
            }

            return PartialView("_NavigationPublic");
        }
    }
}