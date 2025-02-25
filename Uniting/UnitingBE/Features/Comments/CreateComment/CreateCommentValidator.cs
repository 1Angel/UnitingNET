using FluentValidation;

namespace UnitingBE.Features.Comments.CreateComment
{
    public class CreateCommentValidator: AbstractValidator<CreateCommentRequest>
    {
        public CreateCommentValidator()
        {
            RuleFor(x => x.body).NotEmpty().MaximumLength(250).MinimumLength(3);
        }
    }
}
