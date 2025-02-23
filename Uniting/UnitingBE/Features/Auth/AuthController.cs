using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
