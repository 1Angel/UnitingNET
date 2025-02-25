using FluentValidation;
using MediatR;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Entities;

namespace UnitingBE.Features.Comments.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly IValidator<CreateCommentRequest> _validator;
        private readonly CurrentUser _currentUser;
        public CreateCommentHandler(AppDBContext context, IValidator<CreateCommentRequest> validator, CurrentUser currentUser)
        {
            _context = context;
            _validator = validator;
            _currentUser = currentUser;
        }
        public async Task<IResult> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            var validate = await _validator.ValidateAsync(request);
            if (!validate.IsValid)
            {
                return Results.BadRequest(validate.ToDictionary());
            }

            Comment comment = new Comment()
            {
                body = request.body,
                PostId = request.postId,
                AppUserId = _currentUser.GetUserId(),
            };

            await _context.comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return Results.Ok();
        }
    }
}
