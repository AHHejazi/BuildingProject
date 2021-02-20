using App.Domain.Entities;
using System.Threading.Tasks;

namespace App.Application.Contracts.Persistence
{
    public interface IProjectRepository : IAsyncRepository<Project>
    {
        Task<bool> IsProjectNameUnique(string nameAr, string nameEn);
    }
}
