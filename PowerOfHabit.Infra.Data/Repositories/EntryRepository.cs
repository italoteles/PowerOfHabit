using Microsoft.EntityFrameworkCore;
using PowerOfHabit.Domain.Entities;
using PowerOfHabit.Domain.Interfaces;
using PowerOfHabit.Infra.Data.Context;

namespace PowerOfHabit.Infra.Data.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        ApplicationDbContext _entryContext;
        public EntryRepository(ApplicationDbContext entryContext)
        {
            _entryContext = entryContext;
        }
        public async Task<Entry> CreateAsync(Entry entry)
        {
            _entryContext.Add(entry);
            await _entryContext.SaveChangesAsync();
            return entry;
        }

        public async Task<Entry> DeleteAsync(Entry entry)
        {
            _entryContext.Remove(entry);
            await _entryContext.SaveChangesAsync();
            return entry;
        }

        public async Task<IEnumerable<Entry>> GetAllAsync()
        {
            return await _entryContext.Entries.ToListAsync();
        }

        public async Task<Entry> GetByIdAsync(int? id)
        {
            return await _entryContext.Entries.FindAsync(id);
        }

        public async Task<Entry> UpdateAsync(Entry entry)
        {
            _entryContext.Update(entry);
            await _entryContext.SaveChangesAsync();
            return entry;
        }
    }
}
