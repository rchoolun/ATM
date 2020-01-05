using NVisionIT.AutomatedTellerMachine.WCFService.DTO;
using System.Collections.Generic;
using System.ServiceModel;

namespace NVisionIT.AutomatedTellerMachine.WCFServicervice
{
    [ServiceContract]
    public interface IAutomatedTellerMachineService
    {
        [OperationContract]
        UserDto GetUser(UserDto loginDTO);

        [OperationContract]
        List<AccountDto> GetAccounts(int cardNumber);

        [OperationContract]
        AccountDto GetAccount(int accountNumber);

        [OperationContract]
        AccountDto DebitAccountPreSelectAmount(int accountNumber, int amount);

        [OperationContract]
        AccountDto DebitAccountUserSelectAmount(int accountNumber, int amount);
    }
}
