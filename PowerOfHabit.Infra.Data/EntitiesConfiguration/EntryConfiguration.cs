using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PowerOfHabit.Domain.Entities;

namespace PowerOfHabit.Infra.Data.EntitiesConfiguration
{
    public class EntryConfiguration : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.HasKey(t => t.EntryId);
            builder.Property(p => p.EntryAmount).HasPrecision(10, 2).IsRequired();

            builder.HasOne(e => e.User).WithMany(e => e.Entries).HasForeignKey(e => e.UserId);
            builder.HasOne(e => e.Group).WithMany(e => e.Entries).HasForeignKey(e => e.GroupId);
        }
    }
}
