using AutoMapper;
using PowerOfHabit.Application.DTOs;
using PowerOfHabit.Application.Interfaces;
using PowerOfHabit.Domain.Entities;
using PowerOfHabit.Domain.Interfaces;

namespace PowerOfHabit.Application.Services
{
    public class RoleService : IRoleService
    {
        private IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;  
        }

        public async Task<IEnumerable<RoleDTO>> GetAllAsync()
        {
            var rolesEntity = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(rolesEntity);
        }

        public async Task<RoleDTO> GetByIdAsync(int? id)
        {
            var roleEntity = await _roleRepository.GetByIdAsync(id);
            return _mapper.Map<RoleDTO>(roleEntity);
        }
        public async Task CreateAsync(RoleDTO roleDTO)
        {
            var roleEntity = _mapper.Map<Role>(roleDTO);
            await _roleRepository.CreateAsync(roleEntity);
        }
        public async Task UpdateAsync(RoleDTO roleDTO)
        {
            var roleEntity = _mapper.Map<Role>(roleDTO);
            await _roleRepository.UpdateAsync(roleEntity);
        }

        public async Task DeleteAsync(int? id)
        {
            var roleEntity = _roleRepository.GetByIdAsync(id).Result;
            await _roleRepository.DeleteAsync(roleEntity);
        }

        
    }
}
