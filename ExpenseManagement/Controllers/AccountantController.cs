using ExpenseManagement.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Web.Mvc;
using ExpenseManagement.Persistence.Repositories;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace ExpenseManagement.Controllers
{
    [Authorize(Roles = "Accountant")]
    public class AccountantController : Controller
    {

        private IExpenseRepository repository;
        private IExpenseItemRepository itemrepo;
        private IExpenseHistoryRepository HistoryRepository;

        public AccountantController(IExpenseRepository expenserepo, IExpenseItemRepository expenseitemrepo,
            IExpenseHistoryRepository history)
        {
            repository = expenserepo;
            itemrepo = expenseitemrepo;
            HistoryRepository = history;

        }

        // GET: Accountant
        public ActionResult PendingExpenses()
        {
            var expenses = repository.GetExpensesNotPaid();
            var viewmodel = new List<ExpenseViewModel>();


            foreach (var item in expenses)
            {
                viewmodel.Add(new ExpenseViewModel()
                {
                    id = item.Id,
                    Description = item.Description,
                    Date = item.ExpenseDate,
                    Username = repository.GetUsername(item.UserId)
                });

            }
            return View(viewmodel);


        }

        public ActionResult Details(int id)
        {
            TempData["id"] = id;
            return View(itemrepo.GetExpenseItemsByExpenseId(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PayExpense(int id)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("PendingExpenses");
            }
            var body = "Expense request was sent";
            var message = new MailMessage();
            message.To.Add(new MailAddress("sevket.cerit@veripark.com"));  // replace with valid value 
            message.From = new MailAddress("sevket.cerit@veripark.com");  // replace with valid value
            message.Subject = "Expense";
            message.Body = string.Format(body);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "sevket.cerit@veripark.com", // replace with valid value
                    Password = "781450Sevko." // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "mail.veripark.com";
                smtp.Port = 25;
                smtp.EnableSsl = false;
                await smtp.SendMailAsync(message);
                var userId = User.Identity.GetUserName();

                HistoryRepository.AddExpenseHistory(id, userId);

                repository.UpdateStatusPayment(id);

                return RedirectToAction("Index", "Home");
                ;
            }

        }
    }
    }


  