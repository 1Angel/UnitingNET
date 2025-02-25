using MediatR;

namespace UnitingBE.Features.posts.DeletePost
{
    public record DeletePostRequest(int postId): IRequest<IResult>;
}
