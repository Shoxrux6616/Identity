namespace SkillSystem.Bll.Services.Helper;

public class JwtSettings
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecurityKey { get; set; }
    public int Lifetime { get; set; }
}
