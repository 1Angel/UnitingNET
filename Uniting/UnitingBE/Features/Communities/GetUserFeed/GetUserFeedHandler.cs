using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Database;
using UnitingBE.Dtos.Communities;

namespace UnitingBE.Features.Communities.GetUserFeed
{
    public class GetUserFeedHandler: IRequestHandler<GetUserFeedRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public GetUserFeedHandler(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(GetUserFeedRequest request, CancellationToken cancellationToken)
        {
            var userFeed = await _context.communitiesFolloweds.SelectMany(x=>x.Community.posts)
                .Include(x=>x.user)
                .Include(x=>x.Community)
                .Where(x=>x.AppUserId == request.userId)
                .OrderByDescending(x=>x.createdDate)
                .ToListAsync();

            var result = _mapper.Map<List<UserFeedResponseDto>>(userFeed);

            return Results.Ok(result);
        }
    }
}
