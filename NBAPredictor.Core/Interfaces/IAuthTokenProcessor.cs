using NBAPredictor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Core.Interfaces
{
    public interface IAuthTokenProvider
    {
        (string jwtToken, DateTime expiresAtUtc) GenerateJwtToken(User user, IList<string> roles);
        string GenerateRefreshToken();
        void WriteAuthTokenAsHttpOnly(string cookieName, string token, DateTime expiration);

        void ClearAuthCookie(string cookieName);

        ClaimsPrincipal? GetClaimsPrincipal();
    }
}
