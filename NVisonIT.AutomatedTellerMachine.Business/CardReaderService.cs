using NVisionIT.AutomatedTelledMachine.Service;
using NVisonIT.AutomatedTellerMachine.Business.ViewModel;
using NVisonIT.AutomatedTellerMachine.Common;
using NVisonIT.AutomatedTellerMachine.Data;

namespace NVisonIT.AutomatedTellerMachine.Business
{
    public class CardReaderService
    {
        private readonly ICardReader cardReader;

        public CardReaderService(Entities context)
        {
            cardReader = new CardReader(context);
        }

        public CardReaderService()
        {
            cardReader = new CardReader();
        }

        /// <summary>
        /// Gets the card information and map into view model
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="pinNumber"></param>
        /// <returns></returns>
        public CardViewModel ReadCard(string cardNumber, int pinNumber)
        {
            var cardDto = cardReader.ReadCard(cardNumber, pinNumber);

            return cardDto.MapProperties<CardViewModel>();
        }

        /// <summary>
        /// Fetch the account by using the card ID
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public AccountViewModel GetAccount(int cardId)
        {
            var accountDto = cardReader.GetAccount(cardId);

            return accountDto.MapProperties<AccountViewModel>();
        }
    }
}
