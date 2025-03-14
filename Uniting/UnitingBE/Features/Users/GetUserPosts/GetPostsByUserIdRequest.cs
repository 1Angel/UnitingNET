using MediatR;

namespace UnitingBE.Features.Users.GetUserFavorites
{
    public record GetPostsByUserIdRequest(string userId): IRequest<IResult>;

}
