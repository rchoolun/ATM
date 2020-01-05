using NVisonIT.AutomatedTellerMachine.Business;
using NVisonIT.AutomatedTellerMachine.Business.ViewModel;
using System.Web.Mvc;

namespace NVisonIT.AutomatedTellerMachine.Controllers
{
    public class PrintController : Controller
    {
        // GET: Print
        public ActionResult Print()
        {
            var cardViewModel = (CardViewModel)Session["LogIn"];

            var accountViewModel = (AccountViewModel)Session["Account"];

            var printService = new PrintService();

            var printViewModel = printService.GetLastTransaction(cardViewModel.Id, accountViewModel.Id);

            return View(printViewModel);
        }
    }
}