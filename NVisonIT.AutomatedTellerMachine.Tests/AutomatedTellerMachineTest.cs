using Effort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NVisionIT.AutomatedTelledMachine.Service;
using NVisonIT.AutomatedTellerMachine.Business;
using NVisonIT.AutomatedTellerMachine.Common.Enum;
using NVisonIT.AutomatedTellerMachine.Data;
using System.Linq;

namespace NVisonIT.AutomatedTellerMachine.Tests
{
    [TestClass]
    public class AutomatedTellerMachineTest
    {
        [TestMethod]
        public void ReadCardFirstAttemptWrongPinTest()
        {
            var connection = EntityConnectionFactory.CreateTransient("name=Entities");

            using (var context = new Entities(connection))
            {
                CardReaderService cardReaderService = new CardReaderService(context);

                context.Cards.Add(new Card { Id = 1, UserId = 1, CardNumber = "12345", Pin = 1234, Status = (int)CardStatus.Active });
                context.Users.Add(new User { Id = 1, UserName = "Test", LoginAttempt = 0, IsLoggedIn = false });
                context.AccountTypes.Add(new AccountType { Id = 1, Name = AccounType.Current.ToString() });
                context.Accounts.Add(new Account { Id = 1, AccountNumber = "1234", CardId = 1, AccountTypeId = 1, AmountAvailable = 500 });
                context.SaveChanges();

                var getCard = cardReaderService.ReadCard("12345", 4564);

                Assert.AreEqual(Message.WrongPasswordFirstAttempt, getCard.UserMessage);
            }

        }

        [TestMethod]
        public void ReadCardSecondAttemptWrongPinTest()
        {
            var connection = EntityConnectionFactory.CreateTransient("name=Entities");

            using (var context = new Entities(connection))
            {
                CardReaderService cardReaderService = new CardReaderService(context);

                context.Cards.Add(new Card { Id = 1, UserId = 1, CardNumber = "12345", Pin = 1234, Status = (int)CardStatus.Active });
                context.Users.Add(new User { Id = 1, UserName = "Test", LoginAttempt = 1, IsLoggedIn = false });
                context.AccountTypes.Add(new AccountType { Id = 1, Name = AccounType.Current.ToString() });
                context.Accounts.Add(new Account { Id = 1, AccountNumber = "1234", CardId = 1, AccountTypeId = 1, AmountAvailable = 500 });
                context.SaveChanges();

                var getCard = cardReaderService.ReadCard("12345", 4564);

                Assert.AreEqual(Message.WrongPasswordSecondAttempt, getCard.UserMessage);
            }

        }

        [TestMethod]
        public void ReadCardThirdAttemptWrongPinTest()
        {
            var connection = EntityConnectionFactory.CreateTransient("name=Entities");

            using (var context = new Entities(connection))
            {
                CardReaderService cardReaderService = new CardReaderService(context);

                context.Cards.Add(new Card { Id = 1, UserId = 1, CardNumber = "12345", Pin = 1234, Status = (int)CardStatus.Active });
                context.Users.Add(new User { Id = 1, UserName = "Test", LoginAttempt = 2, IsLoggedIn = false });
                context.AccountTypes.Add(new AccountType { Id = 1, Name = AccounType.Current.ToString() });
                context.Accounts.Add(new Account { Id = 1, AccountNumber = "1234", CardId = 1, AccountTypeId = 1, AmountAvailable = 500 });
                context.SaveChanges();

                var getCard = cardReaderService.ReadCard("12345", 4564);

                Assert.AreEqual(Message.WrongPasswordRetainCard, getCard.UserMessage);
            }

        }

        [TestMethod]
        public void ReadCardFullWrongPinTest()
        {
            var connection = EntityConnectionFactory.CreateTransient("name=Entities");

            using (var context = new Entities(connection))
            {
                CardReaderService cardReaderService = new CardReaderService(context);

                context.Cards.Add(new Card { Id = 1, UserId = 1, CardNumber = "12345", Pin = 1234, Status = (int)CardStatus.Active });
                context.Users.Add(new User { Id = 1, UserName = "Test", LoginAttempt = 0, IsLoggedIn = false });
                context.AccountTypes.Add(new AccountType { Id = 1, Name = AccounType.Current.ToString() });
                context.Accounts.Add(new Account { Id = 1, AccountNumber = "1234", CardId = 1, AccountTypeId = 1, AmountAvailable = 500 });
                context.SaveChanges();

                var getCard = cardReaderService.ReadCard("12345", 4564);

                Assert.AreEqual(Message.WrongPasswordFirstAttempt, getCard.UserMessage);

                var getCard1 = cardReaderService.ReadCard("12345", 4564);

                Assert.AreEqual(Message.WrongPasswordSecondAttempt, getCard1.UserMessage);

                var getCard2 = cardReaderService.ReadCard("12345", 4564);

                Assert.AreEqual(Message.WrongPasswordRetainCard, getCard2.UserMessage);

                //Check card status after 3rd attempt
                var card = context.Cards.FirstOrDefault(x => x.CardNumber == "12345");

                Assert.AreEqual((int)CardStatus.Inactive, card.Status);

                var user = context.Users.FirstOrDefault(x => x.Id == 1);

                Assert.AreEqual(3, user.LoginAttempt);
            }

        }

        [TestMethod]
        public void ReadCardGoodPinTest()
        {
            var connection = EntityConnectionFactory.CreateTransient("name=Entities");

            using (var context = new Entities(connection))
            {
                CardReaderService cardReaderService = new CardReaderService(context);

                context.Cards.Add(new Card { Id = 1, UserId = 1, CardNumber = "12345", Pin = 1234, Status = (int)CardStatus.Active });
                context.Users.Add(new User { Id = 1, UserName = "Test", LoginAttempt = 0, IsLoggedIn = false });
                context.AccountTypes.Add(new AccountType { Id = 1, Name = AccounType.Current.ToString() });
                context.Accounts.Add(new Account { Id = 1, AccountNumber = "1234", CardId = 1, AccountTypeId = 1, AmountAvailable = 500 });
                context.SaveChanges();

                var getCard = cardReaderService.ReadCard("12345", 1234);
                var user = context.Users.FirstOrDefault(x => x.Id == 1);

                Assert.AreEqual(Message.LoginSuccessful, getCard.UserMessage);
                Assert.AreEqual(true, getCard.IsLoggedIn);
                Assert.AreEqual(0, user.LoginAttempt);

            }

        }

        [TestMethod]
        public void GetAccountFoundTest()
        {
            var connection = EntityConnectionFactory.CreateTransient("name=Entities");

            using (var context = new Entities(connection))
            {
                CardReaderService cardReaderService = new CardReaderService(context);

                context.Cards.Add(new Card { Id = 1, UserId = 1, CardNumber = "12345", Pin = 1234, Status = (int)CardStatus.Active });
                context.Users.Add(new User { Id = 1, UserName = "Test", LoginAttempt = 0, IsLoggedIn = false });
                context.AccountTypes.Add(new AccountType { Id = 1, Name = AccounType.Current.ToString() });
                context.Accounts.Add(new Account { Id = 1, AccountNumber = "1234", CardId = 1, AccountTypeId = 1, AmountAvailable = 500 });
                context.SaveChanges();

                var account = cardReaderService.GetAccount(1);

                Assert.AreEqual(Message.AccountFound, account.UserMessage);

            }

        }

        [TestMethod]
        public void GetAccountNotFoundTest()
        {
            var connection = EntityConnectionFactory.CreateTransient("name=Entities");

            using (var context = new Entities(connection))
            {
                CardReaderService cardReaderService = new CardReaderService(context);

                context.Cards.Add(new Card { Id = 1, UserId = 1, CardNumber = "12345", Pin = 1234, Status = (int)CardStatus.Active });
                context.Users.Add(new User { Id = 1, UserName = "Test", LoginAttempt = 0, IsLoggedIn = false });
                context.AccountTypes.Add(new AccountType { Id = 1, Name = AccounType.Current.ToString() });
                context.Accounts.Add(new Account { Id = 1, AccountNumber = "1234", CardId = 1, AccountTypeId = 1, AmountAvailable = 500 });
                context.SaveChanges();

                var account = cardReaderService.GetAccount(100);

                Assert.AreEqual(Message.AccountNotFound, account.UserMessage);

            }

        }

        [TestMethod]
        public void DebitAccountRightAmountTest()
        {
            var connection = EntityConnectionFactory.CreateTransient("name=Entities");

            using (var context = new Entities(connection))
            {
                CashDispenser cashDispenser = new CashDispenser(context);

                context.Cards.Add(new Card { Id = 1, UserId = 1, CardNumber = "12345", Pin = 1234, Status = (int)CardStatus.Active });
                context.Users.Add(new User { Id = 1, UserName = "Test", LoginAttempt = 0, IsLoggedIn = false });
                context.AccountTypes.Add(new AccountType { Id = 1, Name = AccounType.Current.ToString() });
                context.Accounts.Add(new Account { Id = 1, AccountNumber = "1234", CardId = 1, AccountTypeId = 1, AmountAvailable = 500 });
                context.SaveChanges();

                var account = cashDispenser.DebitCash(1, 200);

                var transactionHistory = context.TransactionHistories.FirstOrDefault();

                Assert.AreEqual(Message.RequestedAmountDebited, account.UserMessage);
                Assert.IsNotNull(transactionHistory);

            }

        }

        [TestMethod]
        public void DebitAccountInsufficientAmountTest()
        {
            var connection = EntityConnectionFactory.CreateTransient("name=Entities");

            using (var context = new Entities(connection))
            {
                CashDispenser cashDispenser = new CashDispenser(context);

                context.Cards.Add(new Card { Id = 1, UserId = 1, CardNumber = "12345", Pin = 1234, Status = (int)CardStatus.Active });
                context.Users.Add(new User { Id = 1, UserName = "Test", LoginAttempt = 0, IsLoggedIn = false });
                context.AccountTypes.Add(new AccountType { Id = 1, Name = AccounType.Current.ToString() });
                context.Accounts.Add(new Account { Id = 1, AccountNumber = "1234", CardId = 1, AccountTypeId = 1, AmountAvailable = 500 });
                context.SaveChanges();

                var account = cashDispenser.DebitCash(1, 2000);

                var transactionHistory = context.TransactionHistories.FirstOrDefault();

                Assert.AreEqual(Message.InsufficientFunds, account.UserMessage);
                Assert.AreEqual(2000, transactionHistory.TransactionAmount);

            }

        }

        [TestMethod]
        public void DebitAccountUnAuthorizedAmountTest()
        {
            var connection = EntityConnectionFactory.CreateTransient("name=Entities");

            using (var context = new Entities(connection))
            {
                CashDispenser cashDispenser = new CashDispenser(context);

                context.Cards.Add(new Card { Id = 1, UserId = 1, CardNumber = "12345", Pin = 1234, Status = (int)CardStatus.Active });
                context.Users.Add(new User { Id = 1, UserName = "Test", LoginAttempt = 0, IsLoggedIn = false });
                context.AccountTypes.Add(new AccountType { Id = 1, Name = AccounType.Current.ToString() });
                context.Accounts.Add(new Account { Id = 1, AccountNumber = "1234", CardId = 1, AccountTypeId = 1, AmountAvailable = 500 });
                context.SaveChanges();

                var account = cashDispenser.DebitCash(1, 101);

                var transactionHistory = context.TransactionHistories.FirstOrDefault();

                Assert.AreEqual(Message.AmountRequestedNotAuthorized, account.UserMessage);
                Assert.AreEqual(101, transactionHistory.TransactionAmount);

            }

        }
    }
}
