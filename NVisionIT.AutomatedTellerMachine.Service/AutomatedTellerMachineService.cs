using NVisionIT.AutomatedTellerMachine.WCFService.BusinessLogic;
using NVisionIT.AutomatedTellerMachine.WCFService.DTO;
using System.Collections.Generic;

namespace NVisionIT.AutomatedTellerMachine.WCFServicervice
{
    public class AutomatedTellerMachineService : IAutomatedTellerMachineService
    {
        public AccountDto DebitAccountUserSelectAmount(int accountNumber, int amount)
        {
            return Business.Instance.DebitAccountUserSelectAmount(accountNumber, amount);
        }

        public AccountDto DebitAccountPreSelectAmount(int accountNumber, int amount)
        {
            return Business.Instance.DebitAccountPreSelectAmount(accountNumber, amount);
        }

        public AccountDto GetAccount(int accountNumber)
        {
            return Business.Instance.GetAccount(accountNumber);
        }

        public List<AccountDto> GetAccounts(int cardNumber)
        {
            return Business.Instance.GetAccounts(cardNumber);
        }

        public UserDto GetUser(UserDto userDto)
        {
            return Business.Instance.GetUser(userDto);
        }
    }  
}
