using MediatR;

namespace UnitingBE.Features.Auth.GetBookmarksByUser
{
    public record GetBookmarksByUserRequest(string userId): IRequest<IResult>;
    
}
