using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Common;
using UnitingBE.Dtos.Posts;
using UnitingBE.Features.posts.CreatePost;
using UnitingBE.Features.posts.DeletePost;
using UnitingBE.Features.posts.GetAllCommunityPosts;
using UnitingBE.Features.posts.GetPostById;

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

        [Authorize]
        [HttpPost("posts")]
        public async Task<ActionResult> Create([FromRoute] int communityId, [FromBody] CreatePostRequest request)
        {
            request.communityId = communityId;
            //ar request = new CreatePostRequest(communityId, description);
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("posts")]
        public async Task<PageResponse<List<ResponseDto<PostResponseDto>>>> Get([FromRoute] int communityId, [FromQuery] GetAllCommunityPostsRequest request)
        {
            request.communityId = communityId;
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpGet("posts/{postId:int}")]
        public async Task<ResponseDto<PostResponseDto>> GetById([FromRoute] int postId)
        {
            var result = await _mediator.Send(new GetPostByIdRequest(postId));
            return result;
        }

        [Authorize]
        [HttpDelete("posts/{postId:int}")]
        public async Task<IResult> DeleteById([FromRoute] int postId)
        {
            var result = await _mediator.Send(new DeletePostRequest(postId));
            return result;
        }
    }
}
