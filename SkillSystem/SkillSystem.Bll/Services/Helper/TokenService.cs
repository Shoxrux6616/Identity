using Microsoft.IdentityModel.Tokens;
using SkillSystem.Bll.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkillSystem.Bll.Services.Helper;

public class TokenService : ITokenService
{
    private readonly JwtSettings jwtSettings;

    public TokenService(JwtSettings jwtSettings)
    {
        this.jwtSettings = jwtSettings;
    }

    public string GenerateRefreshToken()
    {
        throw new NotImplementedException();
    }

    public string GenerateToken(UserTokenDto user)
    {
        var IdentityClaims = new Claim[]
        {
            new Claim("UserId",user.UserId.ToString()),
            new Claim("FirstName",user.FirstName.ToString()),
            new Claim("LastName",user.LastName.ToString()),
            new Claim("UserName",user.UserName.ToString()),
            new Claim(ClaimTypes.Email,user.Email.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey!));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiresHours = jwtSettings.Lifetime;
        var token = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: IdentityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        throw new NotImplementedException();
    }
}
