using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UnitingBE.Common;
using UnitingBE.Database;
using UnitingBE.Entities;

namespace UnitingBE.Features.posts.CreatePost
{
    public class CreatePostHandler : IRequestHandler<CreatePostRequest, IResult>
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<CreatePostRequest> _validator;
        private readonly CurrentUser _currentUser;
        public CreatePostHandler(AppDBContext context, IMapper mapper, IValidator<CreatePostRequest> validator, CurrentUser currentUser)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _currentUser = currentUser;
        }
        public async Task<IResult> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            var community = await _context.communities.Where(x=>x.Id == request.communityId).FirstOrDefaultAsync();
            if(community == null)
            {
                return Results.NotFound();
            }

            var validate = await _validator.ValidateAsync(request);
            if (!validate.IsValid)
            {
                return Results.BadRequest(validate.ToDictionary());
            }

            Post post = new Post
            {
                description = request.description,
                CommunityId = community.Id,
                AppUserId =  _currentUser.GetUserId(),
            };

            await _context.posts.AddAsync(post, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Results.Ok();

           
        }
    }
}
