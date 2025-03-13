using MediatR;

namespace UnitingBE.Features.Users.GetUserPosts
{
    public record GetUserPostsRequest(int pageNumber, int pageSize,string userId): IRequest<IResult>;
}
