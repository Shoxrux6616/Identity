using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkillSystem.Bll.Services;
using SkillSystem.Bll.Services.Helper;
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

        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IAuthService, AuthService>();


        builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();
    }
}
