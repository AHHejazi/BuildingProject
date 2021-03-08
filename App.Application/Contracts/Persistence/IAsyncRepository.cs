using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.App.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object entityId);
        Task<T> GetByIdAsync(object id);

        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}
