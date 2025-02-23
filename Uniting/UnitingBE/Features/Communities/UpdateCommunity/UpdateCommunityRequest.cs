using MediatR;

namespace UnitingBE.Features.Communities.UpdateCommunity
{
    public record UpdateCommunityRequest(int communityId, string Name, string Description): IRequest<IResult> { }
}
