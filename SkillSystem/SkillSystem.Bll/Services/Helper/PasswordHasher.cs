namespace SkillSystem.Bll.Services.Helper;

public static class PasswordHasher
{
    public static (string Hash, string Salt) HashPassword(string password)
    {
        var salt = Guid.NewGuid().ToString();
        var hash = BCrypt.Net.BCrypt.HashPassword(password + salt);
        return (Hash: hash, Salt: salt);
    }
    public static bool Verify(string password, string hash, string salt)
    {
        return BCrypt.Net.BCrypt.Verify(password + salt, hash);
    }
}
