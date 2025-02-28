using UnitingBE.Dtos.Auth;
using UnitingBE.Dtos.Comments;

namespace UnitingBE.Dtos.Communities
{
    public class UserFeedResponseDto
    {
        public int Id { get; set; }
        public string description { get; set; }
        public UserDto user { get; set; }
        public DateTime createdDate { get; set; }

        public CommunitiesDto community { get; set; }
    }
}
