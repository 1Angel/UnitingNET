using AutoMapper;
using UnitingBE.Dtos.Comments;
using UnitingBE.Entities;

namespace UnitingBE.Mappers
{
    public class CommentsMapper: Profile
    {
        public CommentsMapper()
        {
            CreateMap<Comment, CommentDto>();
        }
    }
}
