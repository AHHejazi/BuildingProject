using Application.App.Contracts.Persistence;
using Application.App.Services.Components;
using Domain.App.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Contracts.Persistence
{
    public interface IComponentRepository : IAsyncRepository<Component>
    {
        Task<ComponentVM> SearchAsync(ComponentVM componentVM);
        Task<bool> IsComponentNameUnique(string nameAr, string nameEn);

    }
}
