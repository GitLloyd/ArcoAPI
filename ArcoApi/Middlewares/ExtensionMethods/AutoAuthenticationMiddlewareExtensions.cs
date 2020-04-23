using AuthTest.API.Middleware;
using Microsoft.AspNetCore.Builder;

namespace ArcoApi.Middlewares.ExtensionMethods
{
    public static class AutoAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAutoAuthentication(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AutoAuthenticationMiddleware>();
        }
    }
}
