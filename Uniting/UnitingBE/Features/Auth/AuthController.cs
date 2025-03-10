using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Common;
using UnitingBE.Features.Auth.GetBookmarksByUser;
using UnitingBE.Features.Auth.Login;
using UnitingBE.Features.Auth.Register;

namespace UnitingBE.Features.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly CurrentUser _currentUser;
        public AuthController(IMediator mediator, CurrentUser currentUser)
        {
            _mediator = mediator;
            _currentUser = currentUser;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserRequest registerUser)
        {
            var result = await _mediator.Send(registerUser);
            return Ok(result);  
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("bookmarks")]
        public async Task<IResult> GetBookmarksByUser()
        {

            var result = await _mediator.Send(new GetBookmarksByUserRequest(_currentUser.GetUserId()));
            return result;
        }

        [Authorize]
        [HttpGet("hola")]
        public string Hola()
        {
            var userId = _currentUser.GetUserId();
            return $"hola si vez esto estas  autenticado tu id es {userId}";
        }

        [Authorize(Roles ="admin")]
        [HttpGet("admin")]
        public string AdminOnly()
        {
            return "si vez esto sos admin";
        }
    }
}
