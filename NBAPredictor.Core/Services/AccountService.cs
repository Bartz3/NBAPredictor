using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using NBAPredictor.Core.Interfaces;
using NBAPredictor.Domain.Constants;
using NBAPredictor.Domain.Entities;
using NBAPredictor.Domain.Enums;
using NBAPredictor.Domain.Exceptions;
using NBAPredictor.Domain.Exceptions.Account;
using NBAPredictor.Domain.Requests.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NBAPredictor.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAuthTokenProvider _authTokenProvider;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public AccountService(IAuthTokenProvider authTokenProvider,
            UserManager<User> userManager,
            IUserRepository userRepository)
        {
            _authTokenProvider = authTokenProvider;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(RegisterRequest registerRequest)
        {
            var userExists = await _userManager.FindByEmailAsync(registerRequest.Email) != null;

            if (userExists)
            {
                throw new UserAlreadyExistsException(registerRequest.Email);
            }

            var user = User.Create(registerRequest.Email, registerRequest.Username);
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, registerRequest.Password);

            var result = await _userManager.CreateAsync(user);

            if(!result.Succeeded)
                throw new RegistrationFailedException(result.Errors.Select(x => x.Description));

            await _userManager.AddToRoleAsync(user, GetIdentityRoleName(registerRequest.Role));
        }

        public async Task LoginAsync(LoginRequest loginRequest) {
            var user= await _userManager.FindByEmailAsync(loginRequest.Email);

            if(user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
                throw new LoginFailedException(loginRequest.Email);

            IList<string> roles = await _userManager.GetRolesAsync(user);
            await AssignTokensToUser(user, roles);
        }

        public async Task ResetPasswordAsync(ResetPasswordRequest resetRequest)
        {
            var claims = _authTokenProvider.GetClaimsPrincipal();
            var email = claims.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                throw new NoUserFoundException(email);

            var result = await _userManager.ChangePasswordAsync(user, resetRequest.OldPassword, resetRequest.NewPassword);

            if (!result.Succeeded)
                throw new Exception(string.Join(",", result.Errors.Select(e => e.Description)));
        }

        public async Task RefreshTokenAsync(string? refreshToken)
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new RefreshTokenException("Refresh token is missing.");

            var user = await _userRepository.GetUserByRefreshTokenAsync(refreshToken);

            if (user == null)
            {
                throw new RefreshTokenException("Unable to retrive user for refresh token");
            }

            if (user.RefreshTokenExpiresAtUtc < DateTime.Now)
            {
                throw new RefreshTokenException("Refresh token is expired.");
            }

            IList<string> roles = await _userManager.GetRolesAsync(user);
            await AssignTokensToUser(user, roles);
        }

        public async Task LogoutAsync(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user is not null)
            {
                user.RefreshToken = null;
                user.RefreshTokenExpiresAtUtc = null;
                await _userManager.UpdateAsync(user);
            }

            _authTokenProvider.ClearAuthCookie("ACCESS_TOKEN");
            _authTokenProvider.ClearAuthCookie("REFRESH_TOKEN");
        }

        public async Task LoginWithGoogleAsync(ClaimsPrincipal? claimsPrincipal)
        {
            if(claimsPrincipal == null)
            {
                throw new ExternalLoginProviderException("Google", "ClaimsPrincipial == null.");
            }

            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);

            if(email == null)
            {
                throw new ExternalLoginProviderException("Google", "Email == null.");
            }

            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                var newUser = new User
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                 var result = await _userManager.CreateAsync(newUser);

                if (!result.Succeeded)
                {
                    throw new ExternalLoginProviderException("Google",
                        $"Unable to create user: {string.Join(", ",
                            result.Errors.Select(x => x.Description))}");
                }
            }

            var info = new UserLoginInfo("Google",
                claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty,
                "Google");

            var loginResult = await _userManager.AddLoginAsync(user, info);

            if (!loginResult.Succeeded)
            {
                throw new ExternalLoginProviderException("Google",
                $"Unable to login user: {string.Join(", ",
                    loginResult.Errors.Select(x => x.Description))}");
            }

            IList<string> roles = await _userManager.GetRolesAsync(user);
            await AssignTokensToUser(user, roles);
        }

        private async Task AssignTokensToUser(User? user, IList<string>? roles = null)
        {
            var (jwtToken, expirationDateInUtc) = _authTokenProvider.GenerateJwtToken(user, roles);
            var refreshTokenValue = _authTokenProvider.GenerateRefreshToken();

            var refreshTokenExpirationDateInUtc = DateTime.UtcNow.AddDays(14);

            user.RefreshToken = refreshTokenValue;
            user.RefreshTokenExpiresAtUtc = refreshTokenExpirationDateInUtc;

            await _userManager.UpdateAsync(user);

            _authTokenProvider.WriteAuthTokenAsHttpOnly("ACCESS_TOKEN", jwtToken, expirationDateInUtc);
            _authTokenProvider.WriteAuthTokenAsHttpOnly("REFRESH_TOKEN", user.RefreshToken, refreshTokenExpirationDateInUtc);
        }

        private string GetIdentityRoleName(Role role)
        {
            return role switch
            {
                Role.User => IdentityRoleConstants.User,
                Role.Admin => IdentityRoleConstants.Admin,
                _ => throw new ArgumentOutOfRangeException(nameof(role), role, "Provided role is not supported.")
            };
        }
    }
}
