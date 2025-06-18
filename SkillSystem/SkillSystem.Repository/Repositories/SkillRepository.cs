using Microsoft.EntityFrameworkCore;
using SkillSystem.DataAccess;
using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Repository.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly MainContext MainContext;

    public SkillRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }

    public async Task<long> InsertAsync(Skill skill)
    {
        await MainContext.Skills.AddAsync(skill);
        await MainContext.SaveChangesAsync();
        return skill.SkillId;
    }

    public async Task<ICollection<Skill>> SelectAllAsync()
    {
        var skills = await MainContext.Skills.ToListAsync();
        return skills;
    }

    public async Task<ICollection<Skill>> SelectAllByUserIdAsync(long userId)
    {
        var query = MainContext.Skills.Where(s => s.UserId == userId);
        var skills = await query.ToListAsync();
        return skills;

        //var user = await MainContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);

        //if (user == null)
        //{
        //    throw new Exception($"User with id : {userId} not found");
        //}

        //await MainContext.Entry(user).Collection(u => u.Skills).LoadAsync();

        //return user.Skills;
    }
}