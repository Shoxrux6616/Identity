using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillSystem.Bll.Dtos;
using SkillSystem.Bll.Dtos.UserDto;
using SkillSystem.Bll.Services;

namespace SkillSystem.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{

    private readonly IAuthService AuthService;

    public AuthController(IAuthService authService)
    {
        AuthService = authService;
    }

    [HttpPost("v1/auth/sign-up")]
    public async Task<long> SignUp(UserCreateDto userCreateDto)
    {
        return await AuthService.SignUpAsync(userCreateDto);
    }

    [HttpPost("v1/auth/login")]
    public async Task<LoginResponseDto> Login(LoginDto loginDto)
    {
        return await AuthService.LoginAsync(loginDto);
    }

    [HttpPost("v1/auth/refresh-token")]
    public async Task<LoginResponseDto> RefreshToken(RefreshTokenDto refreshTokenDto)
    {
        return await AuthService.RefreshTokenAsync(refreshTokenDto);
    }
}
