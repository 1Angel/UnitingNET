using AutoMapper;
using UnitingBE.Dtos.FollowingsCommunities;
using UnitingBE.Entities;

namespace UnitingBE.Mappers
{
    public class FollowingsMapper: Profile
    {
        public FollowingsMapper()
        {
            CreateMap<CommunitiesFollowed, FollowingsCommunitiesDto>();
        }
    }
}
