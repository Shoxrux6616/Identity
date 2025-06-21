using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkillSystem.DataAccess.Entities;

namespace SkillSystem.DataAccess.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        builder.HasKey(u => u.UserId);

        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired(false).HasMaxLength(50);

        builder.HasMany(u => u.Skills)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId);

        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
        // ok
    }
}
