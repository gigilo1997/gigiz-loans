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
        string url = ReadUrl(context.Request);
        string request = await ReadRequestBody(context.Request);

        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await _next(context);

        string response = await ReadResponseBody(context.Response);

        _logger.LogInformation("HTTP {@Method} {@Url}\nRequest Body: {@Request}\nResponse Body: {@Response}", context.Request.Method, url, request, response);

        responseBody.Seek(0, SeekOrigin.Begin);
        await responseBody.CopyToAsync(originalBodyStream);
    }

    private static async Task<string> ReadRequestBody(HttpRequest request)
    {
        request.EnableBuffering();
        using var reader = new StreamReader(request.Body, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        request.Body.Position = 0;
        return body;
    }

    private static async Task<string> ReadResponseBody(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var body = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);
        return body;
    }

    private static string ReadUrl(HttpRequest request)
    {
        string url = $"{request.Scheme}:{request.Host}{request.Path}";
        string query = request.QueryString.ToString();

        if (!string.IsNullOrWhiteSpace(query))
            return $"{url}?{query}";

        return url;
    }
}
