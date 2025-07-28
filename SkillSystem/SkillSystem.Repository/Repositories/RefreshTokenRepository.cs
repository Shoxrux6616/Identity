using Microsoft.EntityFrameworkCore;
using SkillSystem.DataAccess;
using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Repository.Repositories;


public class RefreshTokenRepository : IRefreshTokenRepository
{

    private readonly MainContext MainContext;

    public RefreshTokenRepository(MainContext mainDbContext)
    {
        MainContext = mainDbContext;
    }

    public async Task AddRefreshTokenAsync(RefreshToken refreshToken)
    {
        await MainContext.RefreshTokens.AddAsync(refreshToken);
        await MainContext.SaveChangesAsync();
    }

    public async Task RemoveRefreshTokenAsync(string token)
    {
        var rToken = await MainContext.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);

        MainContext.RefreshTokens.Remove(rToken);
        await MainContext.SaveChangesAsync();
    }

    public async Task<RefreshToken> SelectRefreshTokenAsync(string refreshToken, long userId)
    {
        return await MainContext.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken && rt.UserId == userId);
    }
}

