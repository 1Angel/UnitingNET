using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Features.Favorite.CreateFavorite;

namespace UnitingBE.Features.Favorite
{
    
    [ApiController]
    [Authorize]
    [Route("api/posts/{postId}")]
    public class FavoritesController: ControllerBase
    {
        private readonly IMediator _mediator;
        public FavoritesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("favorites")]
        public async Task<IResult> Create([FromRoute] int postId)
        {
            var result = await _mediator.Send(new CreateFavoriteRequest(postId));
            return (IResult)result;
        }
    }
}
