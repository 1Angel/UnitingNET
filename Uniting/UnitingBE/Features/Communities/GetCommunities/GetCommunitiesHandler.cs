using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Dtos.Communities;

namespace UnitingBE.Features.Communities.GetCommunities
{
    public class GetCommunitiesHandler : IRequestHandler<AllCommunitiesRequest, PageResponse<List<CommunityResponseDto>>>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly CurrentUser _currentUser;
        public GetCommunitiesHandler(AppDBContext context, IMapper mapper, CurrentUser currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }
        public async Task<PageResponse<List<CommunityResponseDto>>> Handle(AllCommunitiesRequest request, CancellationToken cancellationToken)
        {
            var queryable = _context.communities.AsQueryable();

            if (!string.IsNullOrEmpty(request.searchTerm))
            {
                queryable = queryable.Where(x=>x.Name.Contains(request.searchTerm));
            }


            var communities = await queryable
                .AsNoTracking()
                .Select(x=> new CommunityResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    isUserFollowing = x.followed.Any(x=>x.AppUserId == _currentUser.GetUserId()),
                    totalMembers = x.followed.Where(f=>f.CommunityId == x.Id).Count(),
                    createdDate = x.createdDate,
                })
                .Skip((request.pageNumber -1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            var totalCount = await queryable.CountAsync();


            return new PageResponse<List<CommunityResponseDto>>(request.pageNumber,request.pageSize, totalCount, communities);
        }
    }
}
