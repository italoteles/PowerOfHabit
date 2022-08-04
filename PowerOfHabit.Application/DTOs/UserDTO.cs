using PowerOfHabit.Domain.Entities;

namespace PowerOfHabit.Application.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserFullName { get; set; }
        public bool UserActived { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; }
        public ICollection<GroupDTO> Groups {get;set;}



    }
}
