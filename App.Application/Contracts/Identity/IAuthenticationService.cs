using Application.App.Models.Authentication;
using System.Threading.Tasks;

namespace Application.App.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
    }
}
