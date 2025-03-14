using MediatR;
using UnitingBE.Common;
using UnitingBE.Dtos.Favorites;

namespace UnitingBE.Features.Users.GetUserFavorites
{
    public record GetUserFavoritesRequest(string userId, int pageNumber, int pageSize): IRequest<PageResponse<List<FavoritesDto>>>;
}
