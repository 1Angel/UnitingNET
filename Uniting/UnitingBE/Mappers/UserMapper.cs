using AutoMapper;
using UnitingBE.Dtos.Auth;
using UnitingBE.Entities;

namespace UnitingBE.Mappers
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<AppUser, UserDto>();
        }
    }
}
