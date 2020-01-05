using NVisionIT.AutomatedTelledMachine.Service.DTO;

namespace NVisionIT.AutomatedTelledMachine.Service
{
    public interface IReceiptPrinter
    {
        PrintDto GetLastTransaction(int cardId, int accountId);
    }
}
