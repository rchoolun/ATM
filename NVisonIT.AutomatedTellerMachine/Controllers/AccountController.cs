using NVisonIT.AutomatedTellerMachine.Business;
using NVisonIT.AutomatedTellerMachine.Business.ViewModel;
using System.Web.Mvc;

namespace NVisonIT.AutomatedTellerMachine.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View(new CardViewModel());
        }

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CardViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Try to login
                CardReaderService cardReaderService = new CardReaderService();

                var cardViewModel = cardReaderService.ReadCard(model.CardNumber, model.Pin.Value);

                if (cardViewModel.IsLoggedIn)
                {
                    //Created a session and put the view model in it
                    Session["LogIn"] = cardViewModel;
                    Session["UserName"] = cardViewModel.UserName;

                    return RedirectToAction("Index", "Home");
                }

                return View(cardViewModel);               
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public ActionResult LogOff()
        {
            //destroy all session objects
            Session.Clear();

            return RedirectToAction("Login", "Account");
        }
    }
}