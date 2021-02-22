using Application.App.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Building.Web.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public string UserId { get; }
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

       
    }
}
