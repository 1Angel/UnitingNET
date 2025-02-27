using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Entities;

namespace UnitingBE.Features.FollowingCommunities.CreateFollow
{
    public class CreateFollowHandler : IRequestHandler<CreateFollowRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly CurrentUser _currentUser;
        public CreateFollowHandler(AppDBContext context, CurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }
        public async Task<IResult> Handle(CreateFollowRequest request, CancellationToken cancellationToken)
        {
            var community = await _context.communities.Where(x => x.Id == request.communityId).FirstOrDefaultAsync();
            var communityFollowedByUser = await _context.communitiesFolloweds
                .Where(x=>x.CommunityId == request.communityId && x.AppUserId == _currentUser.GetUserId())
                .FirstOrDefaultAsync();

            if (communityFollowedByUser == null)
            {
                CommunitiesFollowed new_follow = new CommunitiesFollowed()
                {
                    CommunityId = community.Id,
                    AppUserId = _currentUser.GetUserId(),
                };

                await _context.communitiesFolloweds.AddAsync(new_follow);
                await _context.SaveChangesAsync();
                return Results.Ok("followed");
            }
            else
            {
                _context.communitiesFolloweds.Remove(communityFollowedByUser);
                await _context.SaveChangesAsync();
                return Results.Ok("Unfollowed");
            }
        }
    }
}
