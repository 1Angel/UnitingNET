using MediatR;

namespace UnitingBE.Features.FollowingCommunities.CreateFollow
{
    public record CreateFollowRequest(int communityId): IRequest<IResult>;
}
