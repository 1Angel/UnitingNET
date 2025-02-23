using FluentValidation;

namespace UnitingBE.Features.posts.CreatePost
{
    public class CreatePostValidator: AbstractValidator<CreatePostRequest>
    {
        public CreatePostValidator()
        {
            RuleFor(x => x.description).NotEmpty().MaximumLength(300).MinimumLength(4);
        }
    }
}
