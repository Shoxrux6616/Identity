using SkillSystem.Bll.Dtos.SkillDto;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.DataAccess.Entities;

namespace SkillSystem.Bll.Converter;

public static class Mappings
{
    public static UserGetDto ConvertToUserGetDto(User user)
    {
        return new UserGetDto()
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
    }

    public static User ConvertToUser(UserCreateDto userCreateDto)
    {
        return new User()
        {
            FirstName = userCreateDto.FirstName,
            LastName = userCreateDto.LastName,
            Email = userCreateDto.Email,
            Password = userCreateDto.Password,
            UserName = userCreateDto.UserName,
        };
    }
    
     
}

