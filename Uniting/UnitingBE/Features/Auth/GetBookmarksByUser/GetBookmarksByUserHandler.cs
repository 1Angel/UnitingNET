using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Dtos.Bookmarks;
using UnitingBE.Dtos.Posts;

namespace UnitingBE.Features.Auth.GetBookmarksByUser
{
    public class GetBookmarksByUserHandler: IRequestHandler<GetBookmarksByUserRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly CurrentUser _currentUser;
        private readonly IMapper _mapper;
        public GetBookmarksByUserHandler(AppDBContext context, CurrentUser currentUser, IMapper mapper)
        {
            _context = context;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(GetBookmarksByUserRequest request, CancellationToken cancellationToken)
        {
            var bookmarksUser = await _context.bookmarks
                .Include(x=>x.post)
                .ThenInclude(x=>x.user)
                .Where(x => x.AppUserId == request.userId).ToListAsync();


            var result = _mapper.Map<List<BookmaksDto>>(bookmarksUser);
            return Results.Ok(result);
        }
    }
}
