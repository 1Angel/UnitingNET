using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Database;
using UnitingBE.Dtos.Posts;
using UnitingBE.Features.posts.GetPostById;

namespace UnitingBE.Features.Users.GetUserFavorites
{
    public class GetPostsByUserIdHandler: IRequestHandler<GetPostsByUserIdRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public GetPostsByUserIdHandler(IMapper mapper, AppDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IResult> Handle(GetPostsByUserIdRequest request, CancellationToken cancellationToken)
        {
            var posts = await _context.posts.Where(x => x.AppUserId == request.userId).ToListAsync();

            var result = _mapper.Map<List<PostResponseDto>>(posts);
            return Results.Ok(result);
        }
    }
}
