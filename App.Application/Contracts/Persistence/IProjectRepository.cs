using Domain.App.Entities;
using System.Threading.Tasks;

namespace Application.App.Contracts.Persistence
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
        Task<bool> IsProjectNameUnique(string nameAr, string nameEn);
    }
}
