using NVisonIT.AutomatedTellerMachine.Common.Enum;
using System;

namespace NVisionIT.AutomatedTelledMachine.Service.DTO
{
    public class PrintDto
    {
        public string UserName { get; set; }

        public int? TransactionAmount { get; set; }

        public string AccountNumber { get; set; }

        public string CardNumber { get; set; }

        public TransactionType Transaction { get; set; }

        public TransactionStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
