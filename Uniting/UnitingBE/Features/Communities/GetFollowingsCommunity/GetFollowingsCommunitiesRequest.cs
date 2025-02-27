using MediatR;

namespace UnitingBE.Features.Communities.GetFollowingsCommunity
{
    public record GetFollowingsCommunitiesRequest(string userId): IRequest<IResult>;
}
