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
        public GetCommunityByIdHandler(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommunityResponseDto> Handle(GetCommunityByIdRequest request, CancellationToken cancellationToken)
        {
            var community = await _context.communities
                .Include(x=>x.user)
                .Where(x => x.Id == request.communityId)
                .FirstOrDefaultAsync();
            var result =  _mapper.Map<CommunityResponseDto>(community);
            return result;  
        }
    }
}
