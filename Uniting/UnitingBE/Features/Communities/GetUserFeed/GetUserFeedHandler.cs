using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Dtos.Communities;
using UnitingBE.Dtos.Posts;

namespace UnitingBE.Features.Communities.GetUserFeed
{
    public class GetUserFeedHandler: IRequestHandler<GetUserFeedRequest, PageResponse<List<PostResponseDto>>>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public GetUserFeedHandler(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PageResponse<List<PostResponseDto>>> Handle(GetUserFeedRequest request, CancellationToken cancellationToken)
        {
            //var userFeed = await _context.posts
            //    .Where(p => _context.communitiesFolloweds
            //            .Where(f => f.AppUserId == request.userId)
            //            .Select(f=>f.CommunityId)
            //            .Contains(p.CommunityId))
            //    .Include(x=>x.user)
            //    .Include(x=>x.Community)
            //    .ToListAsync();

            //var result = _mapper.Map<List<PostResponseDto>>(userFeed);
            //return Results.Ok(result);


            var userFeed = await _context.communitiesFolloweds
                .Where(x => x.AppUserId == request.userId)
                .SelectMany(x => x.Community.posts)
                .Include(x => x.user)
                .Include(x => x.Community)
                .OrderByDescending(x => x.Id)
                .Skip((request.pageNumber - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            var totalPosts = userFeed.Count();
            var result = _mapper.Map<List<PostResponseDto>>(userFeed);
           
            return new PageResponse<List<PostResponseDto>>(request.pageNumber, request.pageSize, totalPosts, result);
        }
    }
}
