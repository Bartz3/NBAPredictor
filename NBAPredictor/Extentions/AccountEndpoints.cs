using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NBAPredictor.Core.Interfaces;
using NBAPredictor.Domain.Entities;
using NBAPredictor.Domain.Requests;
using System.Security.Claims;

namespace NBAPredictor.Extentions
{
    public static class AccountEndpoints
    {
        public static IEndpointRouteBuilder MapAccountEndpoints(this IEndpointRouteBuilder routes)
        {
            routes.MapPost("/api/account/login", async (
                LoginRequest loginRequest,
                IAccountService accountService) =>
            {
                await accountService.LoginAsync(loginRequest);
                return Results.Ok();
            });

            routes.MapPost("/api/account/register", async (RegisterRequest registerRequest, IAccountService accountService) =>
            {
                await accountService.RegisterAsync(registerRequest);

                return Results.Ok();
            });

            routes.MapPost("/api/account/refresh", async (HttpContext httpContext, IAccountService accountService) =>
            {
                var refreshToken = httpContext.Request.Cookies["REFRESH_TOKEN"];

                await accountService.RefreshTokenAsync(refreshToken);

                return Results.Ok();
            });

            routes.MapPost("/api/account/logout", async (
                HttpContext httpContext,
                IAccountService accountService) =>
            {
                var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim is null)
                    return Results.Unauthorized();

                var userId = Guid.Parse(userIdClaim.Value);

                await accountService.LogoutAsync(userId);

                return Results.Ok(new { Message = "Logged out successfully" });
            })
            .RequireAuthorization();

            routes.MapPost("/api/account/login/google", ([FromQuery]string returnUrl, LinkGenerator linkGenerator,
                SignInManager<User> signInManager, HttpContext context) =>
            {
                var properties = signInManager.ConfigureExternalAuthenticationProperties("Google",
                    linkGenerator.GetPathByName(context, "GoogleLoginCallback") + $"?returnUrl={returnUrl}");

                return Results.Challenge(properties, ["Google"]);
            });
            // Checking if user have already account associated with email.
            routes.MapPost("/api/account/login/google/callback", async ([FromQuery] string returnUrl, 
                HttpContext context, IAccountService accountService) =>
            {
                var result = await context.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

                if (!result.Succeeded)
                {
                    return Results.Unauthorized();
                }
                await accountService.LoginWithGoogleAsync(result.Principal);

                return Results.Redirect(returnUrl);

            }).WithName("GoogleLoginCallback");

            routes.MapGet("/api/teams", () => Results.Ok(new List<string> { "Hej" })).RequireAuthorization();

            return routes;

        }

    }

}
