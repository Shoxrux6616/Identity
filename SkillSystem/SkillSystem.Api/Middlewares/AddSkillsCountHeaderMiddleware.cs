using SkillSystem.Bll.Services;

namespace SkillSystem.Api.Middlewares;

public class AddSkillsCountHeaderMiddleware
{
    private readonly RequestDelegate Next;
    //private readonly ISkillService SkillService;

    public AddSkillsCountHeaderMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var value = 10;
        context.Response.OnStarting(() => {
            context.Response.Headers.Add("Skill-numbers", $"{value}");
            return Task.CompletedTask;
        });
        await Next(context);
    }
}

public static class AddSkillsCountHeaderMiddlewareExtensions
{
    public static IApplicationBuilder RegisterAddSkillsCountHeaderMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AddSkillsCountHeaderMiddleware>();
    }
}
