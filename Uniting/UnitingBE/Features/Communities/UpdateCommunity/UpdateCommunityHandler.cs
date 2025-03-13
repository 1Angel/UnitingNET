using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;

namespace UnitingBE.Features.Communities.UpdateCommunity
{
    public class UpdateCommunityHandler : IRequestHandler<UpdateCommunityRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly CurrentUser _currentUser;
        public UpdateCommunityHandler(AppDBContext context, CurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }
        public async Task<IResult> Handle(UpdateCommunityRequest request, CancellationToken cancellationToken)
        {
            var communityId = await _context.communities.Where(x => x.Id == request.communityId).FirstOrDefaultAsync();
            if(communityId.AppUserId == _currentUser.GetUserId())
            {
                return Results.Unauthorized();
            }
    
            communityId.Name = request.Name;
            communityId.Description = request.Description;
            
            var result = await _context.SaveChangesAsync();
            return Results.Ok();
        }
    }
}
