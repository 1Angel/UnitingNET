using FluentValidation;

namespace UnitingBE.Features.Communities.UpdateCommunity
{
    public class UpdateCommunityValidator: AbstractValidator<UpdateCommunityRequest>
    {
        public UpdateCommunityValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30).MinimumLength(4);
            RuleFor(x=>x.Description).NotEmpty().MinimumLength(4).MaximumLength(250);
        }
    }
}
