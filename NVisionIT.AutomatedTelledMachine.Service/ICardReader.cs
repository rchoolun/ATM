using NVisionIT.AutomatedTelledMachine.Service.DTO;

namespace NVisionIT.AutomatedTelledMachine.Service
{
    public interface ICardReader
    {
        CardDto ReadCard(string cardNumber, int pinNumber);

        bool IsAuthenticated(int userId);

        AccountDto GetAccount(int cardId);
    }
}
