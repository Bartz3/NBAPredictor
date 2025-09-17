using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NBAPredictor.Core.Interfaces;
using NBAPredictor.Domain.Entities;
using NBAPredictor.Infrastructure.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NBAPredictor.Infrastructure.Provider
{
    public class AuthTokenProvider : IAuthTokenProvider
    {
        private readonly JwtOptions _jwtOptions;
        public readonly IHttpContextAccessor _httpContextAccessor; 
        public AuthTokenProvider(IOptions<JwtOptions> jwtOptions,
            IHttpContextAccessor httpContextAccessor)
        {
            _jwtOptions = jwtOptions.Value;
            _httpContextAccessor = httpContextAccessor;
        }


        public (string jwtToken, DateTime expiresAtUtc) GenerateJwtToken(User user)
        {
            var signingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtOptions.Secret));

            var credentials = new SigningCredentials(
                signingKey,
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.ToString())
            };

            var expires = DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationTimeInMin);

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: expires,
                signingCredentials:credentials);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return (jwtToken, expires);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public void WriteAuthTokenAsHttpOnly(string cookieName, string token,
            DateTime expiration)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName,
                token, new CookieOptions
                {
                    HttpOnly = true,
                    Expires = expiration,
                    IsEssential = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict
                });
        }

        public void ClearAuthCookie(string cookieName)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(cookieName,
            "", new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(-1),
                IsEssential = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });
        }
    }
}
