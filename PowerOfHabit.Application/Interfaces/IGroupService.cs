using PowerOfHabit.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerOfHabit.Application.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<GroupDTO>> GetAllAsync();
        Task<GroupDTO> GetByIdAsync(int id);
        Task CreateAsync(GroupDTO groupDTO);
        Task UpdateAsync(GroupDTO groupDTO);
        Task DeleteAsync(int? id);


    }
}
