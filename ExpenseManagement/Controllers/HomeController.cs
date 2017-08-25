using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ExpenseManagement.Core.ViewModels;

namespace ExpenseManagement.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult ModalPopup()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            ExpenseViewModel model = new ExpenseViewModel();

            return PartialView("_AddUser", model);
        }
        public ActionResult Index()
        {
             string MailToAddress = "cappadox50@gmail.com";
            string MailFromAddress = "sevket.cerit@veripark.com";
                bool UseSsl = true;
             string Username = "sevket.cerit@veripark.com";
             string Password = "781450Sevko.";
             string ServerName = "mail.veripark.com";
            int ServerPort = 25;
            bool WriteAsFile = true;
            string FileLocation = @"c:\Emails";

            using (var smtpClient = new SmtpClient())
            {

                smtpClient.EnableSsl = UseSsl;
                smtpClient.Host = ServerName;
                smtpClient.Port = ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(Username,
                       Password);

                if (WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                        = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");

              

                MailMessage mailMessage = new MailMessage(
                    MailFromAddress,   // From
                    MailToAddress,     // To
                    "New order submitted!",          // Subject
                    body.ToString());                // Body

                if (WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }

                smtpClient.Send(mailMessage);
            }
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}