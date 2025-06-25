using Microsoft.AspNetCore.Mvc;
using SkillSystem.Bll.Dtos.SkillDto;
using SkillSystem.Bll.Services;

namespace SkillSystem.Api.Controllers;

[Route("api/skill")]
[ApiController]
public class SkillController : ControllerBase
{
    private readonly ISkillService SkillService;

    public SkillController(ISkillService skillService)
    {
        SkillService = skillService;
    }

    [HttpPost("add")]
    public async Task<long> PostSkill(SkillCreateDto skillCreateDto)
    {
        return await SkillService.PostAsync(skillCreateDto);
    }

    [HttpGet("get-all")]
    public async Task<ICollection<SkillGetDto>> GetAll()
    {
        return await SkillService.GetAllAsync();
    }

    [HttpGet("get-all-paginated")]
    public async Task<SkillPaginatedDto> GetAll([FromQuery] int skip, [FromQuery] int take)
    {
        return await SkillService.GetAllAsync(skip, take);
    }

    [HttpGet("get-all-by-user-id/{userId}")]
    public async Task<ICollection<SkillGetDto>> GetAllByUserId(long userId)
    {
        return await SkillService.GetAllByUserIdAsync(userId);
    }

    [HttpDelete("delete/{skillId}")]
    public async Task Delete(long skillId)
    {
        await SkillService.DeleteAsync(skillId);
    }

    [HttpPut("update")]
    public async Task Update(SkillUpdateDto skill)
    {
        await SkillService.UpdateAsync(skill);
    }

    [HttpGet("get-by-id/{skillId}")]
    public async Task<SkillGetDto> GetById(long skillId)
    {
        return await SkillService.GetByIdAsync(skillId);
    }
}
