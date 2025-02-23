using MediatR;

namespace UnitingBE.Features.Auth.Register
{
    public record RegisterUserRequest(string username, string email, string password): IRequest<IResult> { }

}
