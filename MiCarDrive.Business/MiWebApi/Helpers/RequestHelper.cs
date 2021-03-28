using Microsoft.AspNetCore.Http;

namespace MiWebApi.Helpers
{
    public static class RequestHelper
    {
        public static string GetTokenFromRequest(HttpRequest request)
        {
            var headers = request.Headers;
            if (!headers.TryGetValue("Token", out var token))
                return null;
            return token;
        }
    }
}
