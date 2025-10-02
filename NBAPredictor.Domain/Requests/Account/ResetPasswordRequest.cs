using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Domain.Requests.Account
{
    public class ResetPasswordRequest
    {
        //public string Email { get; set; } = string.Empty;
        //public string Token { get; set; } = string.Empty;
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
        public string RepeatNewPassword { get; set; } = string.Empty;
    }
}
