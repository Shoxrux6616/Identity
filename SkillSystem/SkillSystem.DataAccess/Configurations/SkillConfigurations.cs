using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkillSystem.DataAccess.Entities;

namespace SkillSystem.DataAccess.Configurations;

public class SkillConfigurations : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.ToTable("Skill");
        builder.HasKey(u => u.SkillId);

        builder.Property(u => u.Type).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Description).IsRequired(false).HasMaxLength(250);
    }
}
