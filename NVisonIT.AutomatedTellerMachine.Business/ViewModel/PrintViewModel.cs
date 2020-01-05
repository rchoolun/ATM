using NVisonIT.AutomatedTellerMachine.Common.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace NVisonIT.AutomatedTellerMachine.Business.ViewModel
{
    public class PrintViewModel
    {
        [Display(Name = "Account Holder")]
        public string UserName { get; set; }

        [Display(Name = "Transaction Amount")]
        public int? TransactionAmount { get; set; }

        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name = "Transaction Type")]
        public TransactionType Transaction { get; set; }

        [Display(Name = "Status")]
        public TransactionStatus Status { get; set; }

        [Display(Name = "Transaction Date")]
        public DateTime CreatedOn { get; set; }
    }
}
