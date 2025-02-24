using FluentValidation;

namespace UnitingBE.Features.Auth.Login
{
    public class LoginUserValidator: AbstractValidator<LoginUserRequest>
    {
        public LoginUserValidator()
        {
            RuleFor(x => x.email).EmailAddress().NotEmpty().MaximumLength(50).MinimumLength(4);
            RuleFor(x=>x.password).NotEmpty().MaximumLength(150).MinimumLength(4);
        }
    }
}
