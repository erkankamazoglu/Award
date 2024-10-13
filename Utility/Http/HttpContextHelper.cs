using Microsoft.AspNetCore.Http;

namespace Utility.Http
{
    public static class HttpContextHelper
    {
        private static IHttpContextAccessor? _httpContextAccessor;

        public static IHttpContextAccessor? GetHttpContextAccessor()
        {
            return _httpContextAccessor;
        }

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext HttpContext => _httpContextAccessor?.HttpContext!;
    }
}