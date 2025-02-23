using MediatR;

namespace UnitingBE.Features.Communities.CreateCommunity
{
    public record CreateCommunityRequest(string Name, string Description): IRequest<IResult> { }

    public record CreateCommunityResponse(string Name, string Description, DateTime createdDate);
}
