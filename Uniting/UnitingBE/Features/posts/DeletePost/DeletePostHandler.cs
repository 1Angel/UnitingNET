using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;

namespace UnitingBE.Features.posts.DeletePost
{
    public class DeletePostHandler : IRequestHandler<DeletePostRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly CurrentUser _currentUser;
        public DeletePostHandler(AppDBContext context, CurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }
        public async Task<IResult> Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            var post = await _context.posts.Where(x => x.Id == request.postId).FirstOrDefaultAsync();
            if (post == null)
            {
                return Results.NotFound();
            }
            else if(post.AppUserId == _currentUser.GetUserId())
            {
                _context.posts.Remove(post);
                await _context.SaveChangesAsync();
                return Results.Ok();
            }
            else
            {
                return Results.Unauthorized();
            }
        }
    }
}
