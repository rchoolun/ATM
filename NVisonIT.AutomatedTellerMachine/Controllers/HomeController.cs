using NVisonIT.AutomatedTellerMachine.Business;
using NVisonIT.AutomatedTellerMachine.Business.ViewModel;
using NVisonIT.AutomatedTellerMachine.Common.Enum;
using System.Web.Mvc;

namespace NVisonIT.AutomatedTellerMachine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["LogIn"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            CardReaderService cardReaderService = new CardReaderService();

            var cardViewModel = (CardViewModel)Session["LogIn"];

            //Gets the account information
            var accountViewModel = cardReaderService.GetAccount(cardViewModel.Id);

            Session["Account"] = accountViewModel;

            return View(accountViewModel);
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        public ActionResult Index(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var account = (AccountViewModel)Session["Account"];

                var amountToDebit = model.UserAmountToDebit > 0 ? model.UserAmountToDebit : model.AmountToDebit;

                var transactionService = new TransactionService();

                var accountViewModel = transactionService.DebitCash(account.Id, amountToDebit);

                if(accountViewModel.UserMessage == Message.AmountRequestedNotAuthorized)
                {
                    ViewBag.TransactionMessage = "The amount entered " + amountToDebit + " is not authorized";
                }
                else if(accountViewModel.UserMessage == Message.InsufficientFunds)
                {
                    ViewBag.TransactionMessage = "Your account does not have sufficient funds to proceed with this request";
                }
                else if(accountViewModel.UserMessage == Message.AccountNotFound)
                {
                    ViewBag.TransactionMessage = "Account not found";
                }
                else if(accountViewModel.UserMessage == Message.RequestedAmountDebited)
                {
                    ViewBag.TransactionMessage = "The amount of " + amountToDebit + " has been debited from your account";
                }

                return View(accountViewModel);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

    }
}