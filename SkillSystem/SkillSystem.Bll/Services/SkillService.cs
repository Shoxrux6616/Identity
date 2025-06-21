using FluentValidation;
using SkillSystem.Bll.Converter;
using SkillSystem.Bll.Dtos.SkillDto;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.Bll.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository SkillRepository;
    private readonly IUserRepository UserRepository;
    private readonly IValidator<SkillCreateDto> Validator;

    public SkillService(ISkillRepository skillRepository, IValidator<SkillCreateDto> validator, IUserRepository userRepository)
    {
        SkillRepository = skillRepository;
        Validator = validator;
        UserRepository = userRepository;
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
        var result = Validator.Validate(skillCreateDto);

        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }

        var res = await UserRepository.CheckUserExistance(skillCreateDto.UserId);
        if(res == false)
        {
            throw new Exception("User not fount");
        }


        var skill = Mappings.ConvertToSkill(skillCreateDto);
        var skillId = await SkillRepository.InsertAsync(skill);

        return skillId;
    }


}
