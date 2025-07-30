using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillSystem.DataAccess.Entities;

namespace SkillSystem.DataAccess.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(u => u.UserId);

        builder.Property(u => u.Password).IsRequired();

        builder.HasIndex(u => u.Email).IsUnique();
        builder.Property(u => u.Email).IsRequired();

        builder.HasIndex(u => u.UserName).IsUnique();
        builder.Property(u => u.UserName).IsRequired();

        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired(false).HasMaxLength(50);

        builder.HasMany(u => u.RefreshTokens)
            .WithOne(rt => rt.User)
            .HasForeignKey(rf => rf.UserId);
    }
}