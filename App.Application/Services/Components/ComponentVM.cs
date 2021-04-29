using Domain.App.Entities.Lookup;
using Framework.Core.ListManagment;
using PagedList.Core;
using System;

namespace Application.App.Services.Components
{
    public class ComponentVM : PagingDto
    {

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        
        public StaticPagedList<Component> ComponentsList { get; set; }

    }
}
