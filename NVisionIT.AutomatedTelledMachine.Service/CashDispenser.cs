using NVisionIT.AutomatedTelledMachine.Service.DTO;
using NVisonIT.AutomatedTellerMachine.Common.Enum;
using NVisonIT.AutomatedTellerMachine.Data;
using System;
using System.Linq;

namespace NVisionIT.AutomatedTelledMachine.Service
{
    public class CashDispenser : ICashDispenser
    {
        private Entities _context;
        private static int[] AvailableNotes = { 1000, 500, 200, 100, 50 };
        private int AmountStored;

        public CashDispenser(Entities context)
        {
            _context = context;
        }

        public CashDispenser()
        {
            _context = new Entities();
        }

        /// <summary>
        /// Gets the account concerned and debits the amount requested
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public AccountDto DebitCash(int accountId, int amount)
        {
            try
            {
                var account = _context.Accounts.FirstOrDefault(x => x.Id == accountId);

                //store the requested amount 
                AmountStored = amount;

                if (account == null)
                {
                    //return object stating that the accound can not be found
                    return new AccountDto { Id = accountId, IsTransactionSuccessful = false, UserMessage = Message.AccountNotFound };
                }

                int[] noteCounter = new int[AvailableNotes.Length];

                //Check if the amount requested is divisible by 10
                if (amount % 10 != 0 || amount % AvailableNotes.Last() != 0)
                {
                    //Put in transaction history table
                    _context.TransactionHistories.Add(new TransactionHistory
                    {
                        UserId = account.Card.UserId,
                        CardId = account.CardId,
                        AccountId = account.Id,
                        TransactionType = (int)TransactionType.Debit,
                        CreatedOn = DateTime.Now,
                        Status = (int)TransactionStatus.Fail,
                        TransactionAmount = AmountStored
                    });

                    _context.SaveChanges();

                    return new AccountDto { Id = accountId, AmountAvailable = account.AmountAvailable, CardId = account.CardId, AccountNumber = account.AccountNumber, IsTransactionSuccessful = false, UserMessage = Message.AmountRequestedNotAuthorized };
                }

                //Check if the amount requested is bigger than the amount available
                if (amount > account.AmountAvailable)
                {
                    //Put in transaction history table
                    _context.TransactionHistories.Add(new TransactionHistory
                    {
                        UserId = account.Card.UserId,
                        CardId = account.CardId,
                        AccountId = account.Id,
                        TransactionType = (int)TransactionType.Debit,
                        CreatedOn = DateTime.Now,
                        Status = (int)TransactionStatus.Fail,
                        TransactionAmount = AmountStored
                    });

                    _context.SaveChanges();

                    return new AccountDto { Id = accountId, IsTransactionSuccessful = false, UserMessage = Message.InsufficientFunds };
                }

                //Debit the account
                account.AmountAvailable = account.AmountAvailable - amount;
                _context.SaveChanges();

                //fetch the account again
                account = _context.Accounts.FirstOrDefault(x => x.Id == accountId);

                // count notes
                for (int i = 0; i < AvailableNotes.Length; i++)
                {
                    if (amount >= AvailableNotes[i])
                    {
                        noteCounter[i] = amount / AvailableNotes[i];
                        amount = amount - noteCounter[i] * AvailableNotes[i];
                    }
                }

                var noteString = string.Empty;

                //Build the note counter string
                for (int i = 0; i < noteCounter.Length; i++)
                {
                    if (noteCounter[i] != 0)
                    {
                        noteString = noteString + ", " + noteCounter[i] + " X " + AvailableNotes[i];
                    }

                }

                var accountDto = new AccountDto
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber,
                    AmountAvailable = account.AmountAvailable,
                    CardId = account.CardId,
                    IsTransactionSuccessful = true,
                    NoteCounter = noteString.TrimStart(',').TrimStart(),
                    TransactionDate = DateTime.Now,
                    UserMessage = Message.RequestedAmountDebited
                };

                //Put in Transaction history
                _context.TransactionHistories.Add(new TransactionHistory
                {
                    UserId = account.Card.UserId,
                    CardId = account.CardId,
                    AccountId = account.Id,
                    TransactionType = (int)TransactionType.Debit,
                    CreatedOn = DateTime.Now,
                    Status = (int)TransactionStatus.Success,
                    TransactionAmount = AmountStored
                });

                _context.SaveChanges();

                return accountDto;
            }
            catch(Exception)
            {
                throw;
            }
            
        }

    }
}
