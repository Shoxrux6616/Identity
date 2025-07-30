
namespace SkillSystem.Bll.Dtos.UserDto;

public class UserGetDto
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public UserRoleDto UserRole { get; set; }
}
