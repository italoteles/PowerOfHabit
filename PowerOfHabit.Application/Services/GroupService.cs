using AutoMapper;
using PowerOfHabit.Application.DTOs;
using PowerOfHabit.Application.Interfaces;
using PowerOfHabit.Domain.Entities;
using PowerOfHabit.Domain.Interfaces;

namespace PowerOfHabit.Application.Services
{
    public class GroupService : IGroupService
    {
        private IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GroupDTO>> GetAllAsync()
        {
            var groupsEntity = await _groupRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GroupDTO>>(groupsEntity);
        }

        public async Task<GroupDTO> GetByIdAsync(int id)
        {
            var groupEntity = await _groupRepository.GetByIdAsync(id);
            return _mapper.Map<GroupDTO>(groupEntity);
        }
        public async Task CreateAsync(GroupDTO groupDTO)
        {
            var groupEntity = _mapper.Map<Group>(groupDTO);
            await _groupRepository.CreateAsync(groupEntity);
            groupDTO.GroupId = groupEntity.GroupId;
        }

        public async Task DeleteAsync(int? id)
        {
            var groupEntity = _groupRepository.GetByIdAsync(id).Result;
            await _groupRepository.DeleteAsync(groupEntity);
        }

        public async Task UpdateAsync(GroupDTO groupDTO)
        {
            var groupEntity = _mapper.Map<Group>(groupDTO);
            await _groupRepository.UpdateAsync(groupEntity);
        }
    }
}
