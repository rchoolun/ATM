using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVisionIT.AutomatedTellerMachine.WCFService.Models
{
    public enum UserMessage
    {
        WrongPasswordFirstAttempt = 1,
        WrongPasswordSecondAttempt,
        WrongPasswordRetainCard,
        LoginSuccessful,
        UserNotFound,
        LostStolenRetainCard,
        ErrorOccured,
        CheckAccounts,
        AccountNotFound,
        AmountRequestedNotAuthorized,
        InsufficientFunds,
        RequestedAmountDebited,
        Default
    }
}
