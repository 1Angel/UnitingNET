using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Features.posts.CreatePost;

namespace UnitingBE.Features.posts
{
    [Route("api/communities/{communityId:int}")]
    [ApiController]
    public class PostsController: ControllerBase
    {
        private readonly IMediator _mediator;
        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("posts")]
        public async Task<ActionResult> Create([FromRoute] int communityId, [FromBody] CreatePostRequest request)
        {
            request.communityId = communityId;
            //ar request = new CreatePostRequest(communityId, description);
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
