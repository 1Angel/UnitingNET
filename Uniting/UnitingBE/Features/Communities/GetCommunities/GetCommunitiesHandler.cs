using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;

namespace UnitingBE.Features.Communities.GetCommunities
{
    public class GetCommunitiesHandler : IRequestHandler<AllCommunitiesRequest, PageResponse<List<AllCommunitiesResponse>>>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public GetCommunitiesHandler(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PageResponse<List<AllCommunitiesResponse>>> Handle(AllCommunitiesRequest request, CancellationToken cancellationToken)
        {
            var queryable = _context.communities.AsQueryable();

            var communities = await queryable
                .AsNoTracking()
                .Skip((request.pageNumber -1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            var totalCount = await queryable.CountAsync();

            var result = _mapper.Map<List<AllCommunitiesResponse>>(communities);

            return new PageResponse<List<AllCommunitiesResponse>>(request.pageNumber, request.pageSize, totalCount, result);
        }
    }
}
