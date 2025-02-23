using FluentValidation;

namespace UnitingBE.Features.Auth.Register
{
    public class RegisterUserValidator: AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(x=>x.username).NotEmpty().MaximumLength(20).MinimumLength(2);
            RuleFor(x => x.email).EmailAddress().NotEmpty().MaximumLength(30).MinimumLength(4);
            RuleFor(x => x.password).NotEmpty().MinimumLength(4).MaximumLength(15);
        }
    }
}
