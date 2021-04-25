using Application.App.Responses;
using System;
using System.Threading.Tasks;

namespace Application.App.Services.Components
{
    public interface IComponentService
    {
        Task<Guid> AddComponent(ComponentDto component);
        Task<ComponentDto> GetComponentByIdAsync(Guid Id);
        Task UpdateComponent(ComponentDto componentDto);
        Task<ComponentVM> SearchComponentAsync(ComponentVM componentVM);
        Task<BaseResponse> DeleteComponentAsync(Guid componentId);
    }
}
