using System.Security.Claims;

namespace UnitingBE.Common
{
    public class CurrentUser
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CurrentUser(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserId()
        {
            var userId = _contextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Sid);
            return userId;
                
        }
    }
}
