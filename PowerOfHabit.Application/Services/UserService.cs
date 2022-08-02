using AutoMapper;
using PowerOfHabit.Application.DTOs;
using PowerOfHabit.Application.Interfaces;
using PowerOfHabit.Domain.Entities;
using PowerOfHabit.Domain.Interfaces;

namespace PowerOfHabit.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            var usersEntity = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(usersEntity);
        }

        public async Task<UserDTO> GetByIdAsync(int? id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task CreateAsync(UserDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            await _userRepository.CreateAsync(userEntity);
            userDTO.UserId = userEntity.UserId;
        }

        public async Task UpdateAsync(UserDTO userDTO)
        {
            var userEntity = _mapper.Map<User>(userDTO);
            await _userRepository.UpdateAsync(userEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var userEntity = _userRepository.GetByIdAsync(id).Result;
            await _userRepository.DeleteAsync(userEntity);
        }
    }
}
