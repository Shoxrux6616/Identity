using Microsoft.EntityFrameworkCore;
using SkillSystem.DataAccess;
using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Repository.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MainContext MainContext;

    public UserRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<bool> CheckUserExistance(long userId)
    {
        return await MainContext.Users.AnyAsync(x => x.UserId == userId);
    }

    public Task DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<long> InsertAsync(User user)
    {
        await MainContext.Users.AddAsync(user);
        await MainContext.SaveChangesAsync();
        return user.UserId;
    }

    public async Task<User?> SelectUserByUserEmailAsync(string email)
    {
        var user = await MainContext.Users
            .FirstOrDefaultAsync(u => u.Email == email);

        return user;
    }

    public async Task<User?> SelectUserByUserNameAsync(string userName)
    {
        var user = await MainContext.Users
            .FirstOrDefaultAsync(u => u.UserName == userName);

        return user;
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}
