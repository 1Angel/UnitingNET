using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;

namespace UnitingBE.Features.Comments.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly CurrentUser _currentUser;
        public DeleteCommentHandler(AppDBContext context, CurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }
        public async Task<IResult> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = await _context.comments.FindAsync(request.commentId);
            if(comment.AppUserId == _currentUser.GetUserId())
            {
                _context.comments.Remove(comment);
                await _context.SaveChangesAsync();
                return Results.Ok();
            }
            else
            {
                return Results.Forbid();
            }
        }
    }
}
