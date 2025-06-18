using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Bll.Dtos.SkillDto;

public class SkillCreateDto
{
    public string Type { get; set; }
    public string Name { get; set; }
    public SkillLevelDto Level { get; set; }
    public string Description { get; set; }

    public long UserId { get; set; }
}

public enum SkillLevelDto
{
    Elementary,
    PreIntermediate,
    Intermediate,
    UpperIntermediate,
    Advanced,
    Expert,
    Master
}