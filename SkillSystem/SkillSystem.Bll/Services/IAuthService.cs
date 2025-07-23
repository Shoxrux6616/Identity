using SkillSystem.Bll.Dtos;
using SkillSystem.Bll.Dtos.UserDto;

namespace SkillSystem.Bll.Services;

public interface IAuthService
{
    public Task<long> SignUpAsync(UserCreateDto userCreateDto);
    public Task<LoginResponseDto> LoginAsync(LoginDto loginDto);
    public Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
}