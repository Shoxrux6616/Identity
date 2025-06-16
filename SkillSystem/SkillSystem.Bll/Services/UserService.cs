using SkillSystem.Bll.Converter;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Repository.Repositories;

namespace SkillSystem.Bll.Services;

public class UserService : IUserService
{
    private readonly IUserRepository UserRepository;

    public UserService(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public async Task<ICollection<UserGetDto>> GetAllAsync()
    {
        var users = await UserRepository.SelectAllAsync();
        var usersDto = users.Select(u => Mappings.ConvertToUserGetDto(u)).ToList();
        return usersDto;
    }

    public async Task<long> PostAsync(UserCreateDto userCreateDto)
    {
        var user = Mappings.ConvertToUser(userCreateDto);
        var userId = await UserRepository.InsertAsync(user);
        return userId;
    }
}
