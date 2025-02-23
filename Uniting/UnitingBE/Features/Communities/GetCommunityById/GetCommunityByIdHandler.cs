using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Database;

namespace UnitingBE.Features.Communities.GetCommunityById
{
    public class GetCommunityByIdHandler: IRequestHandler<GetCommunityByIdRequest, CommunityResponse>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public GetCommunityByIdHandler(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CommunityResponse> Handle(GetCommunityByIdRequest request, CancellationToken cancellationToken)
        {
            var community = await _context.communities.Where(x => x.Id == request.communityId).FirstOrDefaultAsync();
            var result =  _mapper.Map<CommunityResponse>(community);
            return result;  
        }
    }
}
