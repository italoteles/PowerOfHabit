using PowerOfHabit.Domain.Entities;


namespace PowerOfHabit.Domain.Interfaces
{
    public interface IEntryRepository
    {
        Task<IEnumerable<Entry>> GetAllAsync();
        Task<Entry> GetByIdAsync(int? id);
        Task<Entry> CreateAsync(Entry entry);
        Task<Entry> UpdateAsync(Entry entry);
        Task<Entry> DeleteAsync(Entry entry);
    }
}
}
