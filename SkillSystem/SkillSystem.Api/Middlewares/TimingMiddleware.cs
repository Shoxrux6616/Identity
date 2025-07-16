using System.Diagnostics;

namespace SkillSystem.Api.Middlewares;

public class TimingMiddleware
{
    private readonly RequestDelegate _next;
    public TimingMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        var sw = Stopwatch.StartNew();
        await _next(context);
        sw.Stop();

        Console.WriteLine("Time-sekunds", $"{sw.ElapsedMilliseconds}");
    }
}


public static class TimingMiddlewareExtensions
{
    public static IApplicationBuilder RegisterTimingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<TimingMiddleware>();
    }
}