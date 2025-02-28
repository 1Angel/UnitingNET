using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Database;

namespace UnitingBE.Features.Communities.GetUserFeed
{
    public class GetUserFeedHandler
    {
        private readonly AppDBContext _context;
        public GetUserFeedHandler(AppDBContext context)
        {
            _context = context;
        }

        //public async Task<IResult> Handle(GetUserFeedRequest request, CancellationToken cancellationToken)
        //{
        //    //var posts = await _context.posts
        //    //    .Include(x=>x.user)
        //    //    .Include(x=>x.Community)
        //    //    .ThenInclude(x=>x.followed.Where(x=>x.AppUserId == request.userId).OrderByDescending(x=>x.Id))
        //    //    .ToListAsync();


        //    var posts = await _context



        //    return Results.Ok(posts);
        //}
    }
}
