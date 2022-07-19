using Microsoft.EntityFrameworkCore;
using PowerOfHabit.Domain.Entities;

namespace PowerOfHabit.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Entry> Entries{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
