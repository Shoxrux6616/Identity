using Microsoft.EntityFrameworkCore;
using SkillSystem.DataAccess.Configurations;
using SkillSystem.DataAccess.Entities;

namespace SkillSystem.DataAccess;

public class MainContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new SkillConfigurations());
        modelBuilder.ApplyConfiguration(new UserConfigurations());
    }
}
