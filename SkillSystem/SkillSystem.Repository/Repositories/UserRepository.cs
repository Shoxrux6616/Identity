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

    public async Task<long> InsertAsync(User user)
    {
        await MainContext.Users.AddAsync(user);
        await MainContext.SaveChangesAsync();
        return user.UserId;
    }

    public async Task<ICollection<User>> SelectAllAsync()
    {
        var users = await MainContext.Users.ToListAsync();
        return users;
    }
}
