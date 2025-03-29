using AutoMapper;
using UnitingBE.Dtos.Communities;
using UnitingBE.Features.Communities;
using UnitingBE.Features.Communities.CreateCommunity;
using UnitingBE.Features.Communities.GetCommunities;
using UnitingBE.Features.Communities.GetCommunityById;

namespace UnitingBE.Mappers
{
    public class CommunitiesMapper : Profile
    {
        public CommunitiesMapper()
        {

            CreateMap<Community, AllCommunitiesRequest>();
            CreateMap<Community, CreateCommunityResponse>();

            CreateMap<Community, CommunityResponse>();

            CreateMap<Community, CommunityResponseDto>();

            CreateMap<Community, CommunitiesDto>();
        }
    }
}
