namespace WorkManagerWebApi.Middleware;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.EnableBuffering();

        var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
        context.Request.Body.Position = 0;
        _logger.LogInformation($"Request date: {DateTime.Now} | INFO | Content: {requestBody}");

        var originalBodyStream = context.Response.Body;
        using (var responseBody = new MemoryStream())
        {
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            _logger.LogInformation($"Response date: {DateTime.Now} | {(context.Response.StatusCode < 400 ? "INFO" : "ERROR")} | Status code: {context.Response.StatusCode} | Content: {responseBodyText}");

            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}