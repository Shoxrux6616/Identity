namespace SkillSystem.Bll.Dtos.SkillDto;

public class SkillUpdateDto
{
    public long SkillId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public SkillLevelDto Level { get; set; }
    public string Description { get; set; }

    public long UserId { get; set; }
}
