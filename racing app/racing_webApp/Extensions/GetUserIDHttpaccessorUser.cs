using System.Security.Claims;

namespace racing_webApp.Extensions
{
    public static class GetUserIDHttpaccessorUser
    {
        public static  string GetUserIDAccessor(this ClaimsPrincipal cp) {
            return cp.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
