using FluentValidation;
using SkillSystem.Bll.Services;
using SkillSystem.Bll.Validators;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.Api.Configurations;

public static class DependicyInjectionConfiguration
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddScoped<ISkillRepository, SkillRepository>();
        builder.Services.AddScoped<ISkillService, SkillService>();

        builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<SkillCreateDtoValidator>();
    }
}
