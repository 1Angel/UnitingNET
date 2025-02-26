using MediatR;

namespace UnitingBE.Features.Bookmark.ToggleBookmark
{
    public record ToggleBookmarkRequest(int postId) : IRequest<IResult>;
}
