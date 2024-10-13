using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Utility.Model.Auth;
using Utility.Http;

namespace Utility.Auth
{
    public static class AuthenticationHelper
    {
        private static HttpContext HttpContext => HttpContextHelper.HttpContext;

        public static void ReSignIn(AuthenticationModel authentication)
        {
            SignOut();
            SignIn(authentication);
        }
        public static bool SignIn(AuthenticationModel authentication)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, authentication.Id.ToString()),
                new Claim(ClaimTypes.Name, authentication.Name),
                new Claim(ClaimTypes.Surname, authentication.Surname),
                new Claim(ClaimTypes.Email, authentication.Email),
                new Claim(ClaimTypes.Email, authentication.Email)
            };
            claims.AddRange(authentication.GetUserRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            ClaimsIdentity claimsIdentity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties authenticationProperties = new();

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authenticationProperties).Wait();
            return true;
        }
        public static void SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        #region Get Parameters 
        public static string GetUserId()
        {
            return HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
        }
        public static string GetUserName()
        {
            return HttpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? "";
        }
        public static string GetUserSurname()
        {
            return HttpContext.User.FindFirst(ClaimTypes.Surname)?.Value ?? "";
        }
        public static string GetUserEmail()
        {
            return HttpContext.User.FindFirst(ClaimTypes.Email)?.Value ?? "";
        }
        public static List<string> GetUserRoles()
        {
            List<string> roles = HttpContext.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList();

            return roles;
        }
        #endregion
    }
}
