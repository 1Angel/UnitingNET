using UnitingBE.Dtos.Posts;

namespace UnitingBE.Dtos.Communities
{
    public class CommunityResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<PostResponseDto> posts { get; set; }
        public DateTime createdDate { get; set; }

    }
}
