using PowerOfHabit.Application.DTOs;

namespace PowerOfHabit.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetAllAsync();
        Task<RoleDTO> GetByIdAsync(int? id);
        Task CreateAsync(RoleDTO roleDTO);
        Task UpdateAsync(RoleDTO roleDTO);
        Task DeleteAsync(int? id);


    }
}
