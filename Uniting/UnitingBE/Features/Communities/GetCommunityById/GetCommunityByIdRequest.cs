using MediatR;
using UnitingBE.Dtos.Communities;

namespace UnitingBE.Features.Communities.GetCommunityById
{
    public record GetCommunityByIdRequest(int communityId): IRequest<CommunityResponseDto>;

    public record CommunityResponse(int Id, string Name, string Description, DateTime createdDate);
}
