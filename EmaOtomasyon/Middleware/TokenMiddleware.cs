namespace EmaOtomasyon.Middleware
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IHttpClientFactory httpClientFactory)
        {
            // Session'dan token'ı al
            var accessToken = context.Session.GetString("AccessToken");

            if (!string.IsNullOrEmpty(accessToken))
            {
                // Token'ı isteğe ekle
                var httpClient = httpClientFactory.CreateClient("MyHttpClient");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                context.Items["MyHttpClient"] = httpClient;
            }

            await _next(context);
        }
    }


}
