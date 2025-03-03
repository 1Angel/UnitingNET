using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Database;
using UnitingBE.Common;
using UnitingBE.Dtos.Posts;

namespace UnitingBE.Features.posts.GetAllCommunityPosts
{
    public class GetAllCommunityPostsHandler : IRequestHandler<GetAllCommunityPostsRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public GetAllCommunityPostsHandler(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IResult> Handle(GetAllCommunityPostsRequest request, CancellationToken cancellationToken)
        {
            var posts = await _context.posts
                .Include(x=>x.comments)
                .Where(x => x.CommunityId == request.communityId)
                .Select(x=> new ResponseDto<PostResponseDto>
                {
                    data = new PostResponseDto
                    {
                        Id = x.Id,
                        description = x.description,
                        createdDate = x.createdDate,
                    },
                    TotalBookmarks = x.bookmarks.Count(),
                    TotalComments = x.comments.Count(),
                })
                .Skip((request.pageNumber - 1) * request.pageSize)
                .Take(request.pageSize)
                .ToListAsync();

            return Results.Ok(posts);

            //var result = _mapper.Map<PostResponseDto>(posts);
            //return Results.Ok(new ResponseDto<PostResponseDto>(result)
        }
    }
}
