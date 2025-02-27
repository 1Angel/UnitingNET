using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Database;
using UnitingBE.Dtos.Communities;
using UnitingBE.Dtos.FollowingsCommunities;

namespace UnitingBE.Features.Communities.GetFollowingsCommunity
{
    public class GetFollowingsCommunitiesHandler : IRequestHandler<GetFollowingsCommunitiesRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public GetFollowingsCommunitiesHandler(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IResult> Handle(GetFollowingsCommunitiesRequest request, CancellationToken cancellationToken)
        {
            var followingsCommunties = await _context.communitiesFolloweds
                .Include(x=>x.Community)
                .Where(x=>x.AppUserId == request.userId)
                .ToListAsync();

            var result = _mapper.Map<List<FollowingsCommunitiesDto>>(followingsCommunties);

            return Results.Ok(result);
        }
    }
}
