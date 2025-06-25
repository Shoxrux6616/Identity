using SkillSystem.Bll.Dtos.SkillDto;
using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Bll.Services;

public interface ISkillService
{
    Task<long> PostAsync(SkillCreateDto skillCreateDto);
    Task<ICollection<SkillGetDto>> GetAllAsync();
    Task<SkillPaginatedDto> GetAllAsync(int skip, int take);
    Task<ICollection<SkillGetDto>> GetAllByUserIdAsync(long userId);
    Task DeleteAsync(long userId, long skillId);
    Task UpdateAsync(SkillUpdateDto skillUpdateDto);
    Task<SkillGetDto> GetByIdAsync(long skillId);

}