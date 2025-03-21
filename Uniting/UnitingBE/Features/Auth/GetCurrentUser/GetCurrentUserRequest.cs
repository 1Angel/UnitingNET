using MediatR;
using UnitingBE.Dtos.Auth;

namespace UnitingBE.Features.Auth.GetCurrentUser
{
    public record GetCurrentUserRequest(string userId): IRequest<UserDto>;

}
