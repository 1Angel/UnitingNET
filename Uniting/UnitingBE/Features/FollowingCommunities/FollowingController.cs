using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Features.FollowingCommunities.CreateFollow;

namespace UnitingBE.Features.FollowingCommunities
{
    [ApiController]
    [Authorize]
    [Route("api/communities/{communityId:int}")]
    public class FollowingController: ControllerBase
    {
        private readonly IMediator _mediator;
        public FollowingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("follow")]
        public async Task<IResult> ToggleFollow([FromRoute] int communityId)
        {
            var result = await _mediator.Send(new CreateFollowRequest(communityId)); 
            return result;
        }
    }
}
