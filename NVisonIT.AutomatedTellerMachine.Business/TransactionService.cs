using NVisionIT.AutomatedTelledMachine.Service;
using NVisonIT.AutomatedTellerMachine.Business.ViewModel;
using NVisonIT.AutomatedTellerMachine.Common;
using NVisonIT.AutomatedTellerMachine.Data;

namespace NVisonIT.AutomatedTellerMachine.Business
{
    public class TransactionService
    {
        private readonly ICashDispenser cashDispenser;

        public TransactionService(Entities context)
        {
            cashDispenser = new CashDispenser(context);
        }

        public TransactionService()
        {
            cashDispenser = new CashDispenser();
        }

        public AccountViewModel DebitCash(int accountId, int amount)
        {
            var accountDto = cashDispenser.DebitCash(accountId, amount);

            return accountDto.MapProperties<AccountViewModel>();
        }
    }
}
