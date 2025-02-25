using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using UnitingBE.Dtos.Auth;
using UnitingBE.Entities;
using UnitingBE.Infrastructure.Services;

namespace UnitingBE.Features.Auth.Register
{
    public class RegisterUserHandler: IRequestHandler<RegisterUserRequest, IResult>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IValidator<RegisterUserRequest> _validator;
        private readonly JwtService _jwtService;

        public RegisterUserHandler(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IValidator<RegisterUserRequest> validator, JwtService jwtService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _validator = validator;
            _jwtService = jwtService;
        }

        public async Task<IResult> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {

            var validate = await _validator.ValidateAsync(request, cancellationToken);
            if (!validate.IsValid)
            {
                return Results.BadRequest(validate.ToDictionary());
            }

            var user = await _userManager.FindByEmailAsync(request.email);
            if (user != null)
            {
                return Results.BadRequest($"User with the email {request.email} already exists");
            }

            var newUser = new AppUser
            {
                UserName = request.username,
                Email = request.email,
            };

            var create = await _userManager.CreateAsync(newUser, request.password);
            if (create.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }
            else
            {
                return Results.BadRequest(create.Errors.ToList());
            }

            var token = await _jwtService.GenerateToken(newUser);

            return Results.Ok(new AuthResponseDto(newUser.Id, newUser.Email, token));
        }
    }
}
