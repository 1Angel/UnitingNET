using UnitingBE.Dtos.Auth;
using UnitingBE.Dtos.Comments;
using UnitingBE.Dtos.Communities;
using UnitingBE.Features.Communities;

namespace UnitingBE.Dtos.Posts
{
    public class PostResponseDto
    {
        public int Id { get; set; }
        public required string description { get; set; }
        public required UserDto user { get; set; }
        public CommunitiesDto community { get; set; }
        public List<CommentDto> comments { get; set; }
        public DateTime createdDate { get; set; }
        //public bool? isFavoriteByUser { get; set; }
        //public bool? userCreated { get; set; }
        //public int TotalFavorites { get; set; }
        //public int TotalComments { get; set; }
        //public int TotalBookmarks { get; set; }
    }
}
