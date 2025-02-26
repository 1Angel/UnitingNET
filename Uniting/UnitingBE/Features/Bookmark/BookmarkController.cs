using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Features.Bookmark.ToggleBookmark;

namespace UnitingBE.Features.Bookmark
{
    [ApiController]
    [Authorize]
    [Route("api/posts/{postId}")]
    public class BookmarkController: ControllerBase
    {
        private readonly IMediator _mediator;
        public BookmarkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("bookmark")]
        public async Task<IResult> ToggleBookmark([FromRoute] int postId)
        {
            var result = await _mediator.Send(new ToggleBookmarkRequest(postId));
            return result;
        }
    }
}
