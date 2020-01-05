namespace NVisonIT.AutomatedTellerMachine.Common.Enum
{
    public enum Message
    {
        WrongPasswordFirstAttempt = 1,
        WrongPasswordSecondAttempt,
        WrongPasswordRetainCard,
        PasswordTrialBegin,
        LoginSuccessful,
        UserNotFound,
        LostStolenRetainCard,
        ErrorOccured,
        CheckAccounts,
        AccountNotFound,
        AccountFound,
        CardNotFound,
        AmountRequestedNotAuthorized,
        InsufficientFunds,
        RequestedAmountDebited,
        Default
    }
}
