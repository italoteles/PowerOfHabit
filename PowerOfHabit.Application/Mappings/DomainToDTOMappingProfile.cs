using AutoMapper;
using PowerOfHabit.Application.DTOs;
using PowerOfHabit.Domain.Entities;

namespace PowerOfHabit.Application.Mappins
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Entry, EntryDTO>().ReverseMap();
        }
        
    }
}
