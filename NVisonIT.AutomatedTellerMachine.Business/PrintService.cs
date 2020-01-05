using NVisionIT.AutomatedTelledMachine.Service;
using NVisonIT.AutomatedTellerMachine.Business.ViewModel;
using NVisonIT.AutomatedTellerMachine.Common;
using NVisonIT.AutomatedTellerMachine.Data;

namespace NVisonIT.AutomatedTellerMachine.Business
{
    public class PrintService
    {
        private readonly IReceiptPrinter receiptPrinter;

        public PrintService(Entities context)
        {
            receiptPrinter = new ReceiptPrinter(context);
        }

        public PrintService()
        {
            receiptPrinter = new ReceiptPrinter();
        }
        
        public PrintViewModel GetLastTransaction(int cardId, int accountId)
        {
            var printDto = receiptPrinter.GetLastTransaction(cardId, accountId);

            return printDto.MapProperties<PrintViewModel>();
        }
    }
}
