using Microsoft.EntityFrameworkCore;
using PowerOfHabit.Domain.Entities;
using PowerOfHabit.Domain.Interfaces;
using PowerOfHabit.Infra.Data.Context;

namespace PowerOfHabit.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext _userContext;

        public UserRepository(ApplicationDbContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            _userContext.Add(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(User user)
        {
            _userContext.Remove(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userContext.Users.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int? id)
        {
            return await _userContext.Users.FindAsync(id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            _userContext.Update(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        async Task<User> IUserRepository.GetRoleUser(int id)
        {
            return await _userContext.Users.Include(c => c.Role)
                .SingleOrDefaultAsync(p => p.UserId == id);
        }
    }
}
