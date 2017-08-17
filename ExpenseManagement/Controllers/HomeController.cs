using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExpenseManagement.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult ModalPopup()
        {
            return View();
        }
        public ActionResult Index()
        {
            //if (ModelState.IsValid)
            //{
            //    var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            //    var message = new MailMessage();
            //    message.To.Add(new MailAddress("cappadox50@gmail.com"));  // replace with valid value 
            //    message.From = new MailAddress("sevketcrt@gmail.com");  // replace with valid value
            //    message.Subject = "Test Mail";
            //    message.Body = string.Format(body, "dsadas", "ewqeq", "edsfgdfd");
            //    message.IsBodyHtml = true;

            //    using (var smtp = new SmtpClient())
            //    {
            //        var credential = new NetworkCredential
            //        {
            //            UserName = "sevketcrt@gmail.com",  // replace with valid value
            //            Password = "781450sevko"  // replace with valid value
            //        };
            //        smtp.Credentials = credential;
            //        smtp.Host = "smtp.gmail.com";
            //        smtp.Port = 587;
            //        //smtp.EnableSsl = true;
            //        await smtp.SendMailAsync(message);
            //        return RedirectToAction("Index");
            //    }
            //}
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