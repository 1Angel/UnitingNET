using MediatR;
using Microsoft.AspNetCore.Identity;
using UnitingBE.Entities;
using UnitingBE.Infrastructure.Services;

namespace UnitingBE.Features.Auth.Login
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, IResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtService _jwtService;
        public LoginUserHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, JwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }
        public async Task<IResult> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.email);
            if(user == null)
            {
                return Results.BadRequest($"user with the email {request.email} dot no exists");
            };

            var cheeckPassword = await _userManager.CheckPasswordAsync(user, request.password);
            if (!cheeckPassword)
            {
                return Results.BadRequest("password not dot match");
            }

            var token = await _jwtService.GenerateToken(user);

            return Results.Ok(token);
        }
    }
}
