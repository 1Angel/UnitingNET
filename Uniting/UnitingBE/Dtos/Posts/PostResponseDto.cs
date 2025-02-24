using UnitingBE.Dtos.Auth;
using UnitingBE.Features.Communities;

namespace UnitingBE.Dtos.Posts
{
    public class PostResponseDto
    {
        public int Id { get; set; }
        public string description { get; set; }
        public UserDto user { get; set; }
        public DateTime createdDate { get; set; }
    }
}
