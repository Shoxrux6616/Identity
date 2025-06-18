using SkillSystem.Bll.Converter;
using SkillSystem.Bll.Dtos.SkillDto;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.Bll.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository SkillRepository;

    public SkillService(ISkillRepository skillRepository)
    {
        SkillRepository = skillRepository;
    }

    public async Task<ICollection<SkillGetDto>> GetAllAsync()
    {
        var skills = await SkillRepository.SelectAllAsync();
        var skillsGetDto = skills.Select(s => Mappings.ConvertToSkillGetDto(s)).ToList();
        
        return skillsGetDto;
    }

    public async Task<ICollection<SkillGetDto>> GetAllByUserIdAsync(long userId)
    {
        var skills = await SkillRepository.SelectAllByUserIdAsync(userId);
        var skillsGetDto = skills.Select(s => Mappings.ConvertToSkillGetDto(s)).ToList();

        return skillsGetDto;
    }

    public async Task<long> PostAsync(SkillCreateDto skillCreateDto)
    {
        var skill = Mappings.ConvertToSkill(skillCreateDto);
        var skillId = await SkillRepository.InsertAsync(skill);

        return skillId;
    }
}
