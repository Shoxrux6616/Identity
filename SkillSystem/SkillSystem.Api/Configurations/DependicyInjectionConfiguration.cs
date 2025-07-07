using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SkillSystem.Bll.DesignPatternServices;
using SkillSystem.Bll.Services;
using SkillSystem.Bll.Validators;
using SkillSystem.DataAccess;
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

        builder.Services.AddScoped<IG11Service, G11Service>();

        builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<SkillCreateDtoValidator>();

        builder.Services.AddTransient<ForLoopOddSumStrategy>();
        builder.Services.AddTransient<ForeachLoopOddSumStrategy>();
        builder.Services.AddTransient<LinqOddSumStrategy>();

        builder.Services.AddSingleton<OddSumStrategyResolver>();
        builder.Services.AddScoped<OddSumContext>();

        var strategyType = builder.Configuration["OddSum:Strategy"]?.ToLower();
        DesignPatternSettings designPatternSettings = new DesignPatternSettings()
        {
            StrategyType = strategyType
        };
        builder.Services.AddSingleton<DesignPatternSettings>(designPatternSettings);
    }
}
