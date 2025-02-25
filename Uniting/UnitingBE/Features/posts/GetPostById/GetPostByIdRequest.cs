using MediatR;
using UnitingBE.Dtos.Posts;

namespace UnitingBE.Features.posts.GetPostById
{
    public record GetPostByIdRequest(int postId): IRequest<PostResponseDto>;
}
