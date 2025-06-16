using SkillSystem.Bll.Services;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.Api.Configurations;

public static class DependicyInjectionConfiguration
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();


    }
}
