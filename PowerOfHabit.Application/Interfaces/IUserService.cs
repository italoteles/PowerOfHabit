using PowerOfHabit.Application.DTOs;

namespace PowerOfHabit.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(int? id);
        Task CreateAsync(UserDTO userDTO);
        Task UpdateAsync(UserDTO userDTO);
        Task DeleteAsync(int id);
    }
}
