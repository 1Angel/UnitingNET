using AutoMapper;
using FluentValidation;
using MediatR;
using UnitingBE.Database;

namespace UnitingBE.Features.Communities.CreateCommunity
{
    public class CreateCommunityHandler : IRequestHandler<CreateCommunityRequest, IResult>
    {
        private readonly IValidator<CreateCommunityRequest> validator;
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public CreateCommunityHandler(IValidator<CreateCommunityRequest> validator, AppDBContext context, IMapper mapper)
        {
            this.validator = validator;
            _context = context;
            _mapper = mapper;
        }
        public async Task<IResult> Handle(CreateCommunityRequest request, CancellationToken cancellationToken)
        {
            var validateresult = await validator.ValidateAsync(request);
            if (!validateresult.IsValid)
            {
                Console.WriteLine(validateresult.Errors.ToList());
                return Results.BadRequest(validateresult.ToDictionary());
            }

            Community newCommunity = new Community
            {
                Name = request.Name,
                Description = request.Description
            };

            var result = _context.communities.AddAsync(newCommunity);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<CreateCommunityResponse>(result.Result.Entity);

            return Results.Ok(response);
        }
    }
}
