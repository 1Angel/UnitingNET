using UnitingBE.Dtos.Auth;
using UnitingBE.Dtos.Posts;

namespace UnitingBE.Dtos.Communities
{
    public class CommunityResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? isUserFollowing { get; set; }  
        public List<PostResponseDto> posts { get; set; }
        public UserDto User { get; set; }
        public DateTime createdDate { get; set; }

    }
}
