using NVisonIT.AutomatedTellerMachine.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVisionIT.AutomatedTelledMachine.Service.DTO
{
   public class CardDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }   
        public string CardNumber { get; set; }
        public int? Pin { get; set; }
        public bool IsLoggedIn { get; set; }
        public int Attempt { get; set; }
        public Message UserMessage { get; set; }

        public string DisplayMessage { get; set; }
    }
}
