using SkillSystem.Bll.Dtos.SkillDto;

namespace SkillSystem.Bll.Services;

public interface ISkillService
{
    Task<long> PostAsync(SkillCreateDto skillCreateDto);
    Task<ICollection<SkillGetDto>> GetAllAsync();
    Task<ICollection<SkillGetDto>> GetAllByUserIdAsync(long userId);
}