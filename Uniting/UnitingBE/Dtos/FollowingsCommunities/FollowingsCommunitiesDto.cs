using UnitingBE.Dtos.Communities;
using UnitingBE.Entities;
using UnitingBE.Features.Communities;

namespace UnitingBE.Dtos.FollowingsCommunities
{
    public class FollowingsCommunitiesDto
    {
        public int Id { get; set; }
        public CommunityResponseDto Community { get; set; }

    }
}
