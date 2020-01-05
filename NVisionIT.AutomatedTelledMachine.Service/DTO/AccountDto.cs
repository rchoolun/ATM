using NVisonIT.AutomatedTellerMachine.Common.Enum;
using System;

namespace NVisionIT.AutomatedTelledMachine.Service.DTO
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public int CardId { get; set; }
        public AccounType AccountType { get; set; }
        public int AmountAvailable { get; set; }
        public int AmountToDebit { get; set; }
        public int UserAmountToDebit { get; set; }
        public Message UserMessage { get; set; }
        public bool IsTransactionSuccessful { get; set; }
        public DateTime TransactionDate { get; set; }
        public string NoteCounter { get; set; }
    }
}
