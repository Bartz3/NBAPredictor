using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiresAtUtc { get; set; }

        public static User Create(string email, string username)
        {
            return new User
            {
                Email = email,
                UserName = username
            };
            
        }
    }
}
