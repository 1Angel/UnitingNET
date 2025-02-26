using MediatR;
using UnitingBE.Common;

namespace UnitingBE.Features.Communities.GetCommunities
{
    public record AllCommunitiesRequest(int pageNumber, int pageSize, string? searchTerm): IRequest<PageResponse<List<AllCommunitiesResponse>>>;
    public record AllCommunitiesResponse(int Id, string Name, string Description, DateTime createdDate);

}
