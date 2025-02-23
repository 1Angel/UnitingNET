using MediatR;

namespace UnitingBE.Features.Communities.GetCommunityById
{
    public record GetCommunityByIdRequest(int communityId): IRequest<CommunityResponse>;

    public record CommunityResponse(int Id, string Name, string Description, DateTime createdDate);
}
