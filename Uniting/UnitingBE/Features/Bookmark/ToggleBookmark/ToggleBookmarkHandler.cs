using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Entities;

namespace UnitingBE.Features.Bookmark.ToggleBookmark
{
    public class ToggleBookmarkHandler : IRequestHandler<ToggleBookmarkRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly CurrentUser _currentUser;
        public ToggleBookmarkHandler(AppDBContext context, CurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }
        public async Task<IResult> Handle(ToggleBookmarkRequest request, CancellationToken cancellationToken)
        {
            var post = await _context.posts.FindAsync(request.postId, cancellationToken);
            var bookmarkId = await _context.bookmarks
                .Where(x => x.PostId == request.postId && x.AppUserId == _currentUser.GetUserId())
                .FirstOrDefaultAsync();

            if (bookmarkId == null)
            {
                Bookmarks newBookmark = new Bookmarks()
                {
                    AppUserId = _currentUser.GetUserId(),
                    PostId = request.postId,
                };

                await _context.bookmarks.AddAsync(newBookmark);
                await _context.SaveChangesAsync();
                return Results.Ok("save");
            }
            else
            {
                _context.bookmarks.Remove(bookmarkId);
                await _context.SaveChangesAsync();
                return Results.Ok("delete");
            }
        }
    }
}
