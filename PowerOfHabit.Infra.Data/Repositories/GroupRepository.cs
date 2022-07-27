using Microsoft.EntityFrameworkCore;
using PowerOfHabit.Domain.Entities;
using PowerOfHabit.Domain.Interfaces;
using PowerOfHabit.Infra.Data.Context;

namespace PowerOfHabit.Infra.Data.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        ApplicationDbContext _groupContext;
        public GroupRepository(ApplicationDbContext context)
        {
            _groupContext = context;
        }
        public async Task<Group> CreateAsync(Group group)
        {
            _groupContext.Add(group);
            await _groupContext.SaveChangesAsync();
            return group;
        }

        public async Task<Group> DeleteAsync(Group group)
        {
            _groupContext.Remove(group);
            await _groupContext.SaveChangesAsync();
            return group;
        }

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _groupContext.Groups.ToListAsync();
        }

        public async Task<Group> GetByIdAsync(int? id)
        {
            return await _groupContext.Groups.FindAsync(id);
        }

        public async Task<Group> UpdateAsync(Group group)
        {
            _groupContext.Update(group);
            await _groupContext.SaveChangesAsync();
            return group;
        }
    }
}
