namespace SkillSystem.Bll.Dtos.SkillDto;

public class SkillPaginatedDto
{
    public long TotalCount { get; set; }
    public ICollection<SkillGetDto> SkillGetDtos { get; set; }
}
