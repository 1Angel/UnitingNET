using MediatR;
using UnitingBE.Common;
using UnitingBE.Dtos.Communities;

namespace UnitingBE.Features.Communities.GetCommunities
{
    public record AllCommunitiesRequest(int pageNumber, int pageSize, string? searchTerm): IRequest<PageResponse<List<CommunityResponseDto>>>;
    //public record AllCommunitiesResponse(int Id, string Name, string Description, DateTime createdDate);

}
