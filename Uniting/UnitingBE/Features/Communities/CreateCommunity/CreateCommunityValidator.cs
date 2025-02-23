using FluentValidation;

namespace UnitingBE.Features.Communities.CreateCommunity
{
    //public record CreateCommunityDto(string Name, string Description);
    public class CreateCommunityValidator: AbstractValidator<CreateCommunityRequest>
    {
        public CreateCommunityValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(30).MinimumLength(4);
            RuleFor(x=>x.Description).NotEmpty().MinimumLength(4).MaximumLength(250);
            //RuleFor(x => x.imageUrl).Empty();
        }
    }
}
