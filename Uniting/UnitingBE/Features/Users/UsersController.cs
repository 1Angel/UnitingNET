using MediatR;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Common;
using UnitingBE.Dtos.Favorites;
using UnitingBE.Features.Users.GetUserFavorites;

namespace UnitingBE.Features.Users
{
    [Route("api/[controller]/{userId}")]
    [ApiController]
    public class UsersController: ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("create-posts")]
        public async Task<IResult> GetPostsByUserIdAsync([FromRoute]  string userId)
        {
            var result = await _mediator.Send(new GetPostsByUserIdRequest(userId));
            return result;
        }

        [HttpGet("favorites")]
        public async Task<PageResponse<List<FavoritesDto>>> GetUserFavorites([FromRoute] string userId, [FromQuery] int pageNumber, int pageSize)
        {
            var result = await _mediator.Send(new GetUserFavoritesRequest(userId, pageNumber, pageSize));   
            return result;
        }
    }
}
