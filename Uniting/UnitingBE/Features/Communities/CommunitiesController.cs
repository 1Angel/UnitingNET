using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Common;
using UnitingBE.Dtos.Communities;
using UnitingBE.Dtos.Posts;
using UnitingBE.Features.Communities.CreateCommunity;
using UnitingBE.Features.Communities.GetCommunities;
using UnitingBE.Features.Communities.GetCommunityById;
using UnitingBE.Features.Communities.GetFollowingsCommunity;

using UnitingBE.Features.Communities.GetUserFeed;


namespace UnitingBE.Features.Communities
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CurrentUser currentUser;

        public CommunitiesController(IMediator mediator, CurrentUser currentUser)
        {
            this._mediator = mediator;
            this.currentUser = currentUser;
        }

        [Authorize]
        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateCommunityRequest createCommunityRequest)
        {
            var result = await _mediator.Send(createCommunityRequest);
            return result;
        }

        [HttpGet]
        public async Task<PageResponse<List<CommunityResponseDto>>> Get([FromQuery] AllCommunitiesRequest request)
        {
            var result = await _mediator.Send(request);
            return result;
        }

        [HttpGet("{communityId:int}")]
        public async Task<CommunityResponseDto> GetById([FromRoute] int communityId)
        {
            var request = new GetCommunityByIdRequest(communityId);
            var result = await _mediator.Send(request);
            return result;
        }

        [Authorize]
        [HttpGet("followings")]
        public async Task<IResult> GetFollowingsCommunitiesByUser()
        {
            var userId = currentUser.GetUserId();
            var result = await _mediator.Send(new GetFollowingsCommunitiesRequest(userId));
            return result;
        }


        [Authorize]
        [HttpGet("feed")]
        public async Task<PageResponse<List<PostResponseDto>>> GetUserFeed([FromQuery] int pageNumber,[FromQuery] int pageSize)
        {
            var result = await _mediator.Send(new GetUserFeedRequest(currentUser.GetUserId(), pageNumber, pageSize));
            return result;
        }

    }
}
