using NVisionIT.AutomatedTelledMachine.Service.DTO;
using NVisonIT.AutomatedTellerMachine.Common.Enum;
using NVisonIT.AutomatedTellerMachine.Data;
using System;
using System.Linq;

namespace NVisionIT.AutomatedTelledMachine.Service
{
    public class CardReader : ICardReader
    {
        private Entities _context;

        public CardReader(Entities context)
        {
            _context = context;
        }

        public CardReader()
        {
            _context = new Entities();
        }

        public bool IsAuthenticated(int userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks the user pin with account provided
        /// Retain card on third attempt
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="pinNumber"></param>
        /// <returns></returns>
        public CardDto ReadCard(string cardNumber, int pinNumber)
        {
            try
            {
                //Get card
                var card = _context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);

                //Check if object is null then return empty object
                if (card == null)
                {
                    //return object with card not registered in system contect administrator
                    return new CardDto { IsLoggedIn = false, UserMessage = Message.CardNotFound };
                }

                if (card.Status == (int)CardStatus.Lost || card.Status == (int)CardStatus.Inactive)
                {
                    //returns object with message that the card has been retained
                    return new CardDto { IsLoggedIn = false, UserMessage = Message.LostStolenRetainCard };
                }

                //Set attempts for pin
                card.User.LoginAttempt = card.User.LoginAttempt + 1;

                _context.SaveChanges();

                var cardDto = new CardDto();

                //Fetch data again
                card = _context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);

                //Check if correct pin supplied. If wrong pin on third attempt hold the card
                if (card.Pin != pinNumber)
                {
                    switch (card.User.LoginAttempt)
                    {
                        case 1:
                            //Set message wrong first attempt
                            cardDto.Attempt = 1;
                            cardDto.UserMessage = Message.WrongPasswordFirstAttempt;

                            card.User.LoginAttempt = 1;
                            break;
                        case 2:
                            cardDto.Attempt = 2;
                            cardDto.UserMessage = Message.WrongPasswordSecondAttempt;

                            card.User.LoginAttempt = 2;
                            break;
                        default:
                            cardDto.Attempt = 3;
                            cardDto.UserMessage = Message.WrongPasswordRetainCard;

                            card.Status = (int)CardStatus.Inactive;
                            card.User.LoginAttempt = 3;
                            break;

                    }

                    cardDto.IsLoggedIn = false;
                }
                else
                {
                    cardDto.Id = card.Id;
                    cardDto.UserId = card.UserId;
                    cardDto.CardNumber = cardNumber;
                    cardDto.UserMessage = Message.LoginSuccessful;
                    cardDto.IsLoggedIn = true;
                    cardDto.UserName = card.User.UserName;

                    card.User.LoginAttempt = 0;
                }

                //Save changes in the DB
                _context.SaveChanges();

                return cardDto;
            }
            catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Fetches the account by using a card ID
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public AccountDto GetAccount(int cardId)
        {
            try
            {
                var account = _context.Accounts.FirstOrDefault(x => x.CardId == cardId);

                if (account == null)
                {
                    return new AccountDto { UserMessage = Message.AccountNotFound };
                }

                return new AccountDto
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    AccountType = (AccounType)account.AccountTypeId,
                    AmountAvailable = account.AmountAvailable,
                    CardId = account.CardId,
                    UserMessage = Message.AccountFound
                };
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}

