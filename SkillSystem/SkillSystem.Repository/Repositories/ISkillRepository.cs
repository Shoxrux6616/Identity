using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Repository.Repositories;

public interface ISkillRepository
{
    Task<long> InsertAsync(Skill skill);
    Task<ICollection<Skill>> SelectAllAsync();
    Task<ICollection<Skill>> SelectAllByUserIdAsync(long userId);
}