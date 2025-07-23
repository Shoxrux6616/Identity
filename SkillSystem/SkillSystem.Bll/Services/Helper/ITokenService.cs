using SkillSystem.Bll.Dtos;
using SkillSystem.Bll.Dtos.UserDto;
using System.Security.Claims;

namespace SkillSystem.Bll.Services.Helper;

public interface ITokenService
{
    public string GenerateToken(UserTokenDto user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}