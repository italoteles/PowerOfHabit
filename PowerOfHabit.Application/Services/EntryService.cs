using AutoMapper;
using PowerOfHabit.Application.DTOs;
using PowerOfHabit.Application.Interfaces;
using PowerOfHabit.Domain.Entities;
using PowerOfHabit.Domain.Interfaces;

namespace PowerOfHabit.Application.Services
{
    public class EntryService : IEntryService
    {
        private IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public EntryService(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;   
        }

        public async Task<IEnumerable<EntryDTO>> GetAllAsync()
        {
            var entriesEntity = await _entryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EntryDTO>>(entriesEntity);
        }

        public async Task<EntryDTO> GetByIdAsync(int? id)
        {
            var entryEntity = await _entryRepository.GetByIdAsync(id);
            return _mapper.Map<EntryDTO>(entryEntity);
        }

        public async Task CreateAsync(EntryDTO entryDTO)
        {
            var entryEntity = _mapper.Map<Entry>(entryDTO);
            await _entryRepository.CreateAsync(entryEntity);
        }

        public async Task UpdateAsync(EntryDTO entryDTO)
        {
            var entryEntity = _mapper.Map<Entry>(entryDTO);
            await _entryRepository.UpdateAsync(entryEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var entryEntity = _entryRepository.GetByIdAsync(id).Result;
            await _entryRepository.DeleteAsync(entryEntity);
        }
    }
}
