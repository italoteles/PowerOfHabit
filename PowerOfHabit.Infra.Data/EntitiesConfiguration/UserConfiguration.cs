using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerOfHabit.Domain.Entities;

namespace PowerOfHabit.Infra.Data.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.UserId);
            builder.Property(p => p.UserName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.UserFullName).HasMaxLength(100);
            builder.Property(p => p.UserPassword).HasMaxLength(6).IsRequired();

            builder.HasOne(e=>e.Role).WithMany(e=>e.Users).HasForeignKey(e=>e.RoleId);

            builder.HasData(new User(1,"123","Admin","Administrador do Sistema",true,1));
            
        }
    }
}
