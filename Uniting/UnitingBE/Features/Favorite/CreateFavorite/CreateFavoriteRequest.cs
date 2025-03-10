using MediatR;

namespace UnitingBE.Features.Favorite.CreateFavorite
{
    public record CreateFavoriteRequest(int postId): IRequest<IResult>;
    
}
