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
        var users = await MainContext.Users
            .Include(u => u.Skills)
            .ToListAsync();

        return users;
    }

    public async Task<User> SelectByIdAsync(long userId)
    {
        var user = await MainContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);

        if(user == null)
        {
            throw new Exception($"User with id : {userId} not found");
        }

        await MainContext.Entry(user).Collection(u => u.Skills).LoadAsync();

        return user;
    }
}
