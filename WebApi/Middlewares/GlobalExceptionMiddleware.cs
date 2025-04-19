using System.Net;
using System.Text.Json;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    // written to switch to other middleware
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context); 
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex); 
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;

        var result = JsonSerializer.Serialize(new
        {
            status = (int)code,
            message = "Error", 
            detail = exception.Message 
        });

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        Console.WriteLine($"[EXCEPTION] {exception.Message}");

        return context.Response.WriteAsync(result);
    }
}
