using NBAPredictor.Domain.Requests;
using System.Security.Claims;
namespace NBAPredictor.Core.Interfaces;

public interface IAccountService
{
    Task RegisterAsync(RegisterRequest registerRequest);
    Task LoginAsync(LoginRequest loginRequest);
    Task RefreshTokenAsync(string? refreshToken);
    Task LogoutAsync(Guid userId);
    Task LoginWithGoogleAsync(ClaimsPrincipal? claimsPrincipal);
}

