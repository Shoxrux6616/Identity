namespace SkillSystem.Bll.Dtos.UserDto;

public class UserCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }
}

public enum UserRoleDto
{
    User,
    Admin,
    SuperAdmin
}
