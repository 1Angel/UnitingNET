﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Dtos.Posts;
using UnitingBE.Features.posts.CreatePost;
using UnitingBE.Features.posts.DeletePost;
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

        [HttpGet("posts/{postId:int}")]
        public async Task<PostResponseDto> GetById([FromRoute] int postId)
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
