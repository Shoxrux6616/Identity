﻿using SkillSystem.Bll.Dtos.UserDto;

namespace SkillSystem.Bll.Dtos;

public class UserTokenDto
{
    public long UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public UserRoleDto UserRole { get; set; }
}
