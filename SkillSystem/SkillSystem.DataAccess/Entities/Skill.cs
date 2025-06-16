namespace SkillSystem.DataAccess.Entities;

public class Skill
{
    public long SkillId { get; set; }
    public string Type { get; set; }
    public string Name { get; set; }
    public SkillLevel Level { get; set; }
    public string Description { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}

public enum SkillLevel
{
    Elementary,
    PreIntermediate,
    Intermediate,
    UpperIntermediate,
    Advanced,
    Expert,
    Master
}