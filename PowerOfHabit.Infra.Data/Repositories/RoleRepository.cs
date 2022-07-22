using Microsoft.EntityFrameworkCore;
using PowerOfHabit.Domain.Entities;
using PowerOfHabit.Domain.Interfaces;
using PowerOfHabit.Infra.Data.Context;

namespace PowerOfHabit.Infra.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        ApplicationDbContext _roleContext;
        public RoleRepository(ApplicationDbContext context)
        {
            _roleContext = context;
        }
        public async Task<Role> CreateAsync(Role role)
        {
            _roleContext.Add(role);
            await _roleContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role> DeleteAsync(Role role)
        {
            _roleContext.Remove(role);
            await _roleContext.SaveChangesAsync();
            return role;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _roleContext.Roles.ToListAsync();
        }

        public async Task<Role> GetByIdAsync(int? id)
        {
            return await _roleContext.Roles.FindAsync(id);
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            _roleContext.Update(role);
            await _roleContext.SaveChangesAsync();
            return role;
        }
    }
}
