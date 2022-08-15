using Microsoft.EntityFrameworkCore;
using PowerOfHabit.Domain.Entities;
using PowerOfHabit.Domain.Interfaces;
using PowerOfHabit.Infra.Data.Context;
using System.Collections;

namespace PowerOfHabit.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext _userContext;

        public UserRepository(ApplicationDbContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<User> Authenticate(string userName, string password)
        {
            return await _userContext.Users.SingleOrDefaultAsync(p => p.UserName == userName && p.UserPassword == password);
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
            return await _userContext.Users.Include(c => c.Role).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int? id)
        {
            return await _userContext.Users.Include(c => c.Groups).SingleOrDefaultAsync(p => p.UserId == id);
        }

        public async Task<User> UpdateAsync(User user)
        {

            
            var userContext = await GetByIdAsync(user.UserId);

            foreach (var groupContext in userContext.Groups)
            {
                bool achou = false;
                foreach (var group in user.Groups)
                {
                    if (group.GroupId == groupContext.GroupId)
                    {
                        achou = true;
                        break;
                    }
                        
                }
                if (!achou)
                {
                    userContext.Groups.Remove(groupContext);
                }
                
            }

            foreach (var group in user.Groups)
            {
                bool achou = false;
                foreach (var groupContext in userContext.Groups)
                {
                    if (group.GroupId == groupContext.GroupId)
                    {
                        achou = true;
                        break;
                    }
                }
                if (!achou)
                {
                    userContext.Groups.Add(group);
                }
            }


            
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAllAsync(User user)
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
