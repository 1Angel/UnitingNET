using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Dtos.Favorites;

namespace UnitingBE.Features.Users.GetUserFavorites
{
    public class GetUserFavoritesHandler : IRequestHandler<GetUserFavoritesRequest, PageResponse<List<FavoritesDto>>>
    {
        private readonly AppDBContext _Context;
        private readonly IMapper _Mapper;
        public GetUserFavoritesHandler(AppDBContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }
        public async Task<PageResponse<List<FavoritesDto>>> Handle(GetUserFavoritesRequest request, CancellationToken cancellationToken)
        {
            var queryable = _Context.favorites.AsQueryable();

            var favorites = await queryable
                .Include(x=>x.post)
                .ThenInclude(x=>x.user)
                .Where(x => x.AppUserId == request.userId).ToListAsync();

            
            var result = _Mapper.Map<List<FavoritesDto>>(favorites);

            var totalCount =  favorites.Count();

            return new PageResponse<List<FavoritesDto>>(request.pageNumber, request.pageSize, totalCount, result);

        }
    }
}
