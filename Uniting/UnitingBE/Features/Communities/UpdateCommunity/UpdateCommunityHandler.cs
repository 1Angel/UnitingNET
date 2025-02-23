using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Database;

namespace UnitingBE.Features.Communities.UpdateCommunity
{
    public class UpdateCommunityHandler : IRequestHandler<UpdateCommunityRequest, IResult>
    {
        private readonly AppDBContext _context;
        public UpdateCommunityHandler(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IResult> Handle(UpdateCommunityRequest request, CancellationToken cancellationToken)
        {
            var communityId = await _context.communities.Where(x => x.Id == request.communityId).FirstOrDefaultAsync();
            if(communityId != null)
            {
                communityId.Name = request.Name;
                communityId.Description = request.Description;
            }

            var result = await _context.SaveChangesAsync();
            return Results.Ok();
        }
    }
}
