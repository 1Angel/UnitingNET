using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Database;

namespace UnitingBE.Features.Users.GetUserPosts
{
    //public class GetUserPostsHandler : IRequestHandler<GetUserPostsRequest, IResult>
    //{
    //    private readonly AppDBContext _dbContext;
    //    private readonly IMapper _mapper;
    //    public GetUserPostsHandler(AppDBContext dbContext, IMapper mapper)
    //    {
    //        _dbContext = dbContext;
    //        _mapper = mapper;
    //    }
    //    public async Task<IResult> Handle(GetUserPostsRequest request, CancellationToken cancellationToken)
    //    {
    //        var queryable = _dbContext.posts.AsQueryable();

    //        var posts = await queryable
    //            .Where(x=>x.AppUserId == request.userId)
    //            .Skip((request.pageNumber - 1)* request.pageSize)
    //            .Take(request.pageSize)
    //            .ToListAsync();
    //    }
    //}
}
