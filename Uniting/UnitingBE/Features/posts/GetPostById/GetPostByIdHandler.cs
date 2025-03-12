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
        private readonly CurrentUser _currentUser;
        public GetPostByIdHandler(AppDBContext context, IMapper mapper, CurrentUser currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }
        public async Task<ResponseDto<PostResponseDto>> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
        {

            var isFavoritedByUser = await _context.favorites.Where(x=>x.PostId == request.postId && x.AppUserId == _currentUser.GetUserId()).AnyAsync();
            var post = await _context.posts
                .Include(x=>x.user)
                .Include(x=>x.favorites)
                .Include(x => x.comments)
                .Include(x=>x.bookmarks)
                .ThenInclude(x => x.user)
                .Where(x => x.Id == request.postId)
                .FirstOrDefaultAsync();

            var result =  _mapper.Map<PostResponseDto>(post);
            return new ResponseDto<PostResponseDto>(result,  isFavoritedByUser, post.favorites.Count, post.comments.Count, post.bookmarks.Count);

        }
    }
}
