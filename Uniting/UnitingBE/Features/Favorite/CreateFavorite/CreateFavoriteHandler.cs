using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Entities;

namespace UnitingBE.Features.Favorite.CreateFavorite
{
    public class CreateFavoriteHandler : IRequestHandler<CreateFavoriteRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly CurrentUser _currentUser;
        public CreateFavoriteHandler(AppDBContext context, CurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }
        public async Task<IResult> Handle(CreateFavoriteRequest request, CancellationToken cancellationToken)
        {
            var post = await _context.posts.Where(x => x.Id == request.postId).FirstOrDefaultAsync();
            if (post != null)
            {
                var new_favorite = new Favorites()
                {
                    PostId = request.postId,
                    AppUserId = _currentUser.GetUserId(),
                };

                await _context.favorites.AddAsync(new_favorite);
                await _context.SaveChangesAsync();
                return Results.Ok();
            }

            return Results.NotFound();
        }
    }
}
