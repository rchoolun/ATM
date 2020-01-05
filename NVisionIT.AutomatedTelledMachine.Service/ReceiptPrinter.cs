using NVisionIT.AutomatedTelledMachine.Service.DTO;
using NVisonIT.AutomatedTellerMachine.Common.Enum;
using NVisonIT.AutomatedTellerMachine.Data;
using System;
using System.Linq;

namespace NVisionIT.AutomatedTelledMachine.Service
{
    public class ReceiptPrinter : IReceiptPrinter
    {
        private Entities _context;

        public ReceiptPrinter(Entities context)
        {
            _context = context;
        }

        public ReceiptPrinter()
        {
            _context = new Entities();
        }

        /// <summary>
        /// Gets the last transaction of the user that allows him to print a recipt
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public PrintDto GetLastTransaction(int cardId, int accountId)
        {
            try
            {
                var transaction = _context.TransactionHistories.OrderByDescending(x => x.CreatedOn).FirstOrDefault();

                var printDto = new PrintDto
                {
                    UserName = transaction.User.UserName,
                    TransactionAmount = transaction.TransactionAmount,
                    AccountNumber = transaction.Account.AccountNumber,
                    CardNumber = transaction.Card.CardNumber,
                    Transaction = (TransactionType)transaction.TransactionType,
                    CreatedOn = transaction.CreatedOn,
                    Status = (TransactionStatus)transaction.Status
                };

                return printDto;
            }
            catch(Exception)
            {
                throw;
            }
           
        }
    }
}
