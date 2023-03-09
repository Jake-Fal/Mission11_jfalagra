using Microsoft.AspNetCore.Http;

namespace Mission09_jfalagra.Infrastructure
{
    public static class UrlExtensions
    {
        public static string PathandQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
            }
}
