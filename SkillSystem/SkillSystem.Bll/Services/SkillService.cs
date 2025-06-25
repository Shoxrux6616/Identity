using FluentValidation;
using Microsoft.AspNetCore.Mvc.Formatters;
using SkillSystem.Bll.Converter;
using SkillSystem.Bll.Dtos.SkillDto;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.DataAccess.Entities;
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

    public async Task<SkillPaginatedDto> GetAllAsync(int skip, int take)
    {
        if (skip < 0) skip = 0;
        if (take < 0 || take > 100) take = 10;

        var skills = await SkillRepository.SelectAllAsync(skip, take);

        var skillPaginatedDto = new SkillPaginatedDto()
        {
            TotalCount = await SkillRepository.SelectCountAllAsync(),
            SkillGetDtos = skills.Select(s => Mappings.ConvertToSkillGetDto(s)).ToList()
        };

        return skillPaginatedDto;
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

    public async Task UpdateAsync(SkillUpdateDto skillUpdateDto)
    {
        Skill? skill = await SkillRepository.SelectByIdAsync(skillUpdateDto.SkillId);

        if (skill == null)
        {
            throw new Exception($"Skill is not found with id : {skillUpdateDto.SkillId} to update");
        }

        if (skillUpdateDto.UserId != skill.UserId)
        {
            throw new Exception($"Skill is not owned by you with id : {skillUpdateDto.UserId} to update");
        }

        skill.Type = skillUpdateDto.Type;
        skill.Name = skillUpdateDto.Name;
        skill.Level = (SkillLevel)skillUpdateDto.Level;
        skill.Description = skillUpdateDto.Description;
        skill.UserId = skillUpdateDto.UserId;

        await SkillRepository.UpdateAsync(skill);
    }

    public async Task DeleteAsync(long userId, long skillId)
    {
        var skill = await SkillRepository.SelectByIdAsync(skillId);

        if (skill == null)
        {
            throw new Exception($"Skill is not found with id : {skillId} to delete");
        }

        if(userId != skill.UserId)
        {
            throw new Exception($"Skill is not owned by you with id : {skillId} to delete");
        }

        await SkillRepository.RemoveAsync(skill);
    }

    public async Task<SkillGetDto> GetByIdAsync(long skillId)
    {
        var skill = await SkillRepository.SelectByIdAsync(skillId);

        if(skill == null)
        {
            throw new Exception($"Skill is not found with id : {skillId}");
        }

        return Mappings.ConvertToSkillGetDto(skill);
    }

}
