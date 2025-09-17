using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Infrastructure.Settings
{
    public class JwtOptions
    {
        public const string JwtOptionsKey = "JwtSettings";

        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpirationTimeInMin { get; set; }
    }
}
