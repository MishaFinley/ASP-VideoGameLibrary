using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FinleyM_VGL
{
    public static class ExtensionHelpers
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static string GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Name);
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.Identity.IsAuthenticated && user.IsInRole("Admin");
        }
        public static bool IsPremium(this ClaimsPrincipal user)
        {
            return user.Identity.IsAuthenticated &&  user.IsInRole("PremiumUser");
        }
    }
}
