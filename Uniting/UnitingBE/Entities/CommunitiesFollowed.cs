using UnitingBE.Features.Communities;

namespace UnitingBE.Entities
{
    public class CommunitiesFollowed
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public AppUser User { get; set; }
        public int CommunityId { get; set; }
        public Community Community { get; set; }
        
    }
}
