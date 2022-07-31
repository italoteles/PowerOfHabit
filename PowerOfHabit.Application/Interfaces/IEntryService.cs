using PowerOfHabit.Application.DTOs;

namespace PowerOfHabit.Application.Interfaces
{
    public interface IEntryService
    {
        Task<IEnumerable<EntryDTO>> GetAllAsync();
        Task<EntryDTO> GetByIdAsync(int? id);
        Task CreateAsync(EntryDTO entryDTO);
        Task UpdateAsync(EntryDTO entryDTO);
        Task DeleteAsync(int id);
    }
}
