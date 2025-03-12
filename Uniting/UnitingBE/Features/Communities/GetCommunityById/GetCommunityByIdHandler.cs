using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Dtos.Communities;

namespace UnitingBE.Features.Communities.GetCommunityById
{
    public class GetCommunityByIdHandler: IRequestHandler<GetCommunityByIdRequest, CommunityResponseDto>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly CurrentUser _currentUser;
        public GetCommunityByIdHandler(AppDBContext context, IMapper mapper, CurrentUser currentUser)
        {
            _context = context;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task<CommunityResponseDto> Handle(GetCommunityByIdRequest request, CancellationToken cancellationToken)
        {

            var isUserFollowing = await _context.communitiesFolloweds.Where(x=>x.CommunityId == request.communityId && x.AppUserId == _currentUser.GetUserId()).AnyAsync();

            var community = await _context.communities
                .Include(x=>x.user)
                .Where(x => x.Id == request.communityId)
                .FirstOrDefaultAsync();
            var result =  _mapper.Map<CommunityResponseDto>(community);
            result.isUserFollowing = isUserFollowing;
            return result;  
        }
    }
}
