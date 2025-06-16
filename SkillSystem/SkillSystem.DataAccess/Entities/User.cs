namespace SkillSystem.DataAccess.Entities;

public class User
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public ICollection<Skill> Skills { get; set; }
}
