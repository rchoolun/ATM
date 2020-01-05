using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NVisionIT.AutomatedTelledMachine.Service.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public bool IsLoggedIn { get; set; }
        public int? LoginAttempt { get; set; }
        public int Status { get; set; }
        public string UserName { get; set; }
    }
}
