using MediatR;

namespace UnitingBE.Features.posts.CreatePost
{
    public class CreatePostRequest : IRequest<IResult>
    {
        public int? communityId { get; set; }
        public string description { get; set; }

    }
}
