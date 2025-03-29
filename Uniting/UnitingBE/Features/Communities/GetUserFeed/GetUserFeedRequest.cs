using MediatR;
using UnitingBE.Common;
using UnitingBE.Dtos.Communities;
using UnitingBE.Dtos.Posts;

namespace UnitingBE.Features.Communities.GetUserFeed
{
    public record GetUserFeedRequest(string userId, int pageNumber, int pageSize): IRequest<PageResponse<List<PostResponseDto>>>;
}
