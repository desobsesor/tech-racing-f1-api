namespace TechRacingF1.WebApi.Auth
{
    public class ApiKeyMiddleware(RequestDelegate next)
    {
        private const string APIKEYNAME = "X-API-Key";

        public async Task InvokeAsync(HttpContext context)
        {
            // Allow swagger access without an API key
            if (context.Request.Path.StartsWithSegments("/swagger") ||
                context.Request.Path.StartsWithSegments("/swagger-ui"))
            {
                await next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Please, provide a API Key");
                return;
            }

            var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = configuration.GetValue<string>($"ApiKeys:{APIKEYNAME}");

            if (string.IsNullOrEmpty(apiKey))
            {
                context.Response.StatusCode = 500; // Internal Server Error
                await context.Response.WriteAsync("API Key configuration is missing");
                return;
            }

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 403; // Forbidden
                await context.Response.WriteAsync("Invalid API Key");
                return;
            }

            await next(context);
        }
    }
}
