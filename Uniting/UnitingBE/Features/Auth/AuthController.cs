using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnitingBE.Features.Auth.Login;
using UnitingBE.Features.Auth.Register;

namespace UnitingBE.Features.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
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
        [HttpGet("hola")]
        public async Task<string> Hola()
        {
            return "hola si vez esto estas  autenticado";
        }

        [Authorize(Roles ="admin")]
        [HttpGet("admin")]
        public async Task<string> AdminOnly()
        {
            return "si vez esto sos admin";
        }
    }
}
