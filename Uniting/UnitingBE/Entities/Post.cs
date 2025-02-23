using UnitingBE.Features.Communities;

namespace UnitingBE.Entities
{
    public class Post
    {
        public int Id {  get; set; }
        public required string description { get;set; }  
        public int CommunityId { get; set; }
        public Community Community { get; set; }

        public DateTime createdDate { get; set; } = DateTime.Now;
    }
}
