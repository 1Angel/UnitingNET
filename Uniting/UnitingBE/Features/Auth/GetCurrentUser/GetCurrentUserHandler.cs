using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UnitingBE.Dtos.Auth;
using UnitingBE.Entities;

namespace UnitingBE.Features.Auth.GetCurrentUser
{
    public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserRequest, UserDto>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public GetCurrentUserHandler(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<UserDto> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.userId);
            var result = _mapper.Map<UserDto>(user);
            return result;
            
        }
    }
}
