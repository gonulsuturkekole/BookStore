public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var path = context.Request.Path;
        var method = context.Request.Method;

        Console.WriteLine($" Request received {method} {path}");

        await _next(context);

        Console.WriteLine($"esponse sent: {context.Response.StatusCode}");
    }
}
