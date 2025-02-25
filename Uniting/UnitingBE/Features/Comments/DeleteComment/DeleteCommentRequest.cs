using MediatR;

namespace UnitingBE.Features.Comments.DeleteComment
{
    public record DeleteCommentRequest(int commentId): IRequest<IResult>;

}
