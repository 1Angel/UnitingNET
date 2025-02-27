using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Common;
using UnitingBE.Dtos.Communities;
using UnitingBE.Features.Communities.CreateCommunity;
using UnitingBE.Features.Communities.GetCommunities;
using UnitingBE.Features.Communities.GetCommunityById;
using UnitingBE.Features.Communities.GetFollowingsCommunity;

namespace UnitingBE.Features.Communities
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunitiesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly CurrentUser currentUser;
        public CommunitiesController(IMediator mediator, CurrentUser currentUser)
        {
            this.mediator = mediator;
            this.currentUser = currentUser;
        }

        [Authorize]
        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateCommunityRequest createCommunityRequest)
        {
            var result = await mediator.Send(createCommunityRequest);
            return result;
        }

        [HttpGet]
        public async Task<PageResponse<List<AllCommunitiesResponse>>> Get([FromQuery] AllCommunitiesRequest request)
        {
            var result = await mediator.Send(request);
            return result;
        }

        [HttpGet("{communityId:int}")]
        public async Task<CommunityResponseDto> GetById([FromRoute] int communityId)
        {
            var request = new GetCommunityByIdRequest(communityId);
            var result = await mediator.Send(request);
            return result;
        }

        [Authorize]
        [HttpGet("followings")]
        public async Task<IResult> GetFollowingsCommunitiesByUser()
        {
            var userId = currentUser.GetUserId();
            var result = await mediator.Send(new GetFollowingsCommunitiesRequest(userId));
            return result;
        }
    }
}
