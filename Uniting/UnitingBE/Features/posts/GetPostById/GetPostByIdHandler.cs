using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Dtos.Posts;

namespace UnitingBE.Features.posts.GetPostById
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdRequest, ResponseDto<PostResponseDto>>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public GetPostByIdHandler(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ResponseDto<PostResponseDto>> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
        {
            var post = await _context.posts
                .Include(x=>x.user)
                .Include(x=>x.favorites)
                .Include(x => x.comments)
                .Include(x=>x.bookmarks)
                .ThenInclude(x => x.user)
                .Where(x => x.Id == request.postId)
                .FirstOrDefaultAsync();

            var result =  _mapper.Map<PostResponseDto>(post);
            return new ResponseDto<PostResponseDto>(result,  post.favorites.Count, post.comments.Count, post.bookmarks.Count);

        }
    }
}
