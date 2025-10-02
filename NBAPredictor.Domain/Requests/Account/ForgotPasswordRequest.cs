using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Domain.Requests.Account
{
    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
    }
}
