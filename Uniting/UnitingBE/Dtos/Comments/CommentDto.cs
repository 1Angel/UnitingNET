using UnitingBE.Dtos.Auth;

namespace UnitingBE.Dtos.Comments
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string body { get; set; }
        public UserDto user { get; set; }
        public DateTime createdDate { get; set; }
    }
}
