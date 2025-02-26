using UnitingBE.Dtos.Posts;
using UnitingBE.Entities;

namespace UnitingBE.Dtos.Bookmarks
{
    public class BookmaksDto
    {
        public int Id { get; set; }
        public PostResponseDto post { get; set; }
        public DateTime createdDate { get; set; } = DateTime.Now;
    }
}
