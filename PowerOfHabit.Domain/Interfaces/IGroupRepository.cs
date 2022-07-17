using PowerOfHabit.Domain.Entities;


namespace PowerOfHabit.Domain.Interfaces
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllAsync();
        Task<Group> GetByIdAsync(int? id);
        Task<Group> CreateAsync(Group group);
        Task<Group> UpdateAsync(Group group);
        Task<Group> DeleteAsync(Group group);
    }
}
