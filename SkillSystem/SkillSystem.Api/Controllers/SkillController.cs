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

    [HttpGet("getAll")]
    public async Task<ICollection<SkillGetDto>> GetAll()
    {
        return await SkillService.GetAllAsync();
    }

    [HttpGet("getAllByUserId/{userId}")]
    public async Task<ICollection<SkillGetDto>> GetAllByUserId(long userId)
    {
        return await SkillService.GetAllByUserIdAsync(userId);
    }
}
