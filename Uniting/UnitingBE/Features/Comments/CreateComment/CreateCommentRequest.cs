using MediatR;

namespace UnitingBE.Features.Comments.CreateComment
{
    public class CreateCommentRequest : IRequest<IResult>
    {
        public int postId { get; set; }
        public string body { get; set; }
    }
}
