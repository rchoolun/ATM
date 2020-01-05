using NVisionIT.AutomatedTelledMachine.Service.DTO;

namespace NVisionIT.AutomatedTelledMachine.Service
{
    public interface ICashDispenser
    {
        AccountDto DebitCash(int accountId, int amount);
    }
}
