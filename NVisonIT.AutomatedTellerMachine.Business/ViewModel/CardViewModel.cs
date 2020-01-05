using NVisonIT.AutomatedTellerMachine.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace NVisonIT.AutomatedTellerMachine.Business.ViewModel
{
    public class CardViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public int? Pin { get; set; }
        public bool IsLoggedIn { get; set; }
        public int Attempt { get; set; }
        public Message UserMessage { get; set; }

        public string DisplayMessage
        {
            get
            {
                if(UserMessage == Message.WrongPasswordFirstAttempt)
                {
                    return "First login attempt failed. Your PIN is incorrect. Please try again";
                }
                else if(UserMessage == Message.WrongPasswordSecondAttempt)
                {
                    return "Second login attempt failed. Your PIN is incorrect. Please try again";
                }
                else if(UserMessage == Message.WrongPasswordRetainCard)
                {
                    return "Third login attempt failed. Your PIN is incorrect. Your card has been retained. Please contact your bank";
                }
                else if(UserMessage == Message.LostStolenRetainCard)
                {
                    return "Login failed. This card has been retained by the bank. Please contact your bank";
                }
                else
                {
                    return "Please select your correct PIN. You have only 3 attempts after which your card will be blocked";
                }
            }           
            set{ }
        }

        public CardViewModel()
        {
            UserMessage = Message.PasswordTrialBegin;
        }
    }
}
