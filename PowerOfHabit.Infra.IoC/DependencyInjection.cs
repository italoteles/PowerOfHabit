using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerOfHabit.Application.Interfaces;
using PowerOfHabit.Application.Mappins;
using PowerOfHabit.Application.Services;
using PowerOfHabit.Domain.Account;
using PowerOfHabit.Domain.Interfaces;
using PowerOfHabit.Infra.Data.Authentication;
using PowerOfHabit.Infra.Data.Context;
using PowerOfHabit.Infra.Data.Repositories;


namespace PowerOfHabit.Infra.IoC
{
    public static  class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                configuration.GetConnectionString("DefaultConnection"), 
                ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")), 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();

            services.AddScoped<IRoleService,RoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IEntryService, EntryService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));


            return services;
        }
    }
}
