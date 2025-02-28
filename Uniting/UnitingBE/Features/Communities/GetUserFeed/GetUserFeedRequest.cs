using MediatR;

namespace UnitingBE.Features.Communities.GetUserFeed
{
    public record GetUserFeedRequest(string userId): IRequest<IResult>;
}
