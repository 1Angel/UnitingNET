using MediatR;

namespace UnitingBE.Features.Auth.Login
{
    public record LoginUserRequest(string email, string password): IRequest<IResult>;
}
