using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Features.Comments.CreateComment;
using UnitingBE.Features.Comments.DeleteComment;

namespace UnitingBE.Features.Comments
{
    [ApiController]
    [Authorize]
    [Route("api/posts/{postId}")]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("comments")]
        public async Task<IResult> Create([FromRoute] int postId, [FromBody] CreateCommentRequest request) 
        {
            request.postId = postId;
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpDelete("comments/{commentId}")]
        public async Task<IResult> DeleteById([FromRoute] int commentId)
        {
            var result = await _mediator.Send(new DeleteCommentRequest(commentId));
            return result;
        }
    }
}
