using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerOfHabit.Domain.Entities;

namespace PowerOfHabit.Infra.Data.EntitiesConfiguration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(t => t.GroupId);
            builder.Property(p => p.GroupName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.GroupDescription).HasMaxLength(300);
            builder.Property(p => p.GroupAmountUnit).HasMaxLength(20).IsRequired();
        }

       
    }
}
