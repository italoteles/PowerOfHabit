using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerOfHabit.Domain.Entities;


namespace PowerOfHabit.Infra.Data.EntitiesConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(t => t.RoleId);
            builder.Property(p => p.RoleName).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Role(1, "Admin"),
                new Role(2, "Creator"),
                new Role(3, "User")
                );
        }
    }
}
