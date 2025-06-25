using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Repository.Repositories;

public interface ISkillRepository
{
    Task<long> InsertAsync(Skill skill);
    Task<ICollection<Skill>> SelectAllAsync();
    Task<ICollection<Skill>> SelectAllAsync(int skip, int take);
    Task<ICollection<Skill>> SelectAllByUserIdAsync(long userId);
    Task<long> SelectCountAllAsync();
    Task RemoveAsync(Skill skill);
    Task UpdateAsync(Skill skill);
    Task<Skill?> SelectByIdAsync(long skillId);
}