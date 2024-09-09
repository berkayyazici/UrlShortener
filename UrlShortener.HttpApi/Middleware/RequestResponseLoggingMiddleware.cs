namespace UrlShortener.HttpApi.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"HTTP Request Information: \n" +
                                   $"Schema: {context.Request.Scheme} \n" +
                                   $"Host: {context.Request.Host} \n" +
                                   $"Path: {context.Request.Path} \n" +
                                   $"QueryString: {context.Request.QueryString} \n" +
                                   $"Request Body: {await ReadRequestBody(context.Request)}");

            var originalBodyStream = context.Response.Body;

            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);

                _logger.LogInformation($"HTTP Response Information: \n" +
                                       $"StatusCode: {context.Response.StatusCode} \n" +
                                       $"Response Body: {await ReadResponseBody(context.Response)}");

                await responseBody.CopyToAsync(originalBodyStream);
            }
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            request.EnableBuffering();
            var body = await new StreamReader(request.Body).ReadToEndAsync();
            request.Body.Position = 0;
            return body;
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);
            return text;
        }
    }

}
