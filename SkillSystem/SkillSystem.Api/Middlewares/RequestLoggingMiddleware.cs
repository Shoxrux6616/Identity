namespace SkillSystem.Api.Middlewares;

public class RequestLoggingMiddleware
{
    private readonly ILogger<RequestLoggingMiddleware> Logger;
    private readonly RequestDelegate Next;
    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        Next = next;
        Logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
        await Next(context);
    }
}


