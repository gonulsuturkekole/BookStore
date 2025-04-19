public class FakeAuthMiddleware
{
    private readonly RequestDelegate _next;

    public FakeAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var authHeader = context.Request.Headers["Authorization"].ToString();

        if (!string.IsNullOrWhiteSpace(authHeader) && authHeader.StartsWith("Bearer "))
        {
            var token = authHeader.Substring("Bearer ".Length).Trim();

            if (token == "1")
            {
                context.Items["UserId"] = 1;
            }
        }

        await _next(context);
    }
}
