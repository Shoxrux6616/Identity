using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSystem.Bll.Dtos.SkillDto;
using SkillSystem.Bll.Services;

namespace SkillSystem.Api.Controllers;

[Authorize]
[Route("api/skill")]
[ApiController]
public class SkillController : ControllerBase
{
    private readonly ISkillService SkillService;
    private readonly IG11Service G11Service;

    public SkillController(ISkillService skillService, IG11Service g11Service)
    {
        SkillService = skillService;
        G11Service = g11Service;
    }

    [HttpPost("add")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    public async Task<long> PostSkill(SkillCreateDto skillCreateDto)
    {
        // G11Service call
        var userId = User.FindFirst("UserId")?.Value;
        var id = long.Parse(userId);

        return await SkillService.PostAsync(skillCreateDto, id);
    }

    
    [HttpGet("get-all")]
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
    public async Task<ICollection<SkillGetDto>> GetAll()
    {
        var userId = User.FindFirst("UserId")?.Value;
        var id = long.Parse(userId);

        return await SkillService.GetAllAsync(id);
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
    public async Task Delete(long userId, long skillId)
    {
        await SkillService.DeleteAsync(userId, skillId);
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
