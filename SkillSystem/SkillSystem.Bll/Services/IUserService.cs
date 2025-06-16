using SkillSystem.Bll.Dtos.UserDto;

namespace SkillSystem.Bll.Services;

public interface IUserService
{
    Task<long> PostAsync(UserCreateDto userCreateDto);
    Task<ICollection<UserGetDto>> GetAllAsync();
}