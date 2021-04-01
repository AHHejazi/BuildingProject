using Application.App.Responses;
using System.Threading.Tasks;

namespace Application.App.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<BaseResponse> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
    }
}
