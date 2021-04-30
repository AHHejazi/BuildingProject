using Domain.App.Entities;
using Domain.App.Entities.Lookup;
using Framework.Core.ListManagment;
using PagedList.Core;
using System;

namespace Application.App.Services.Outbuildings
{
    public class OutbuildingTypeVM : PagingDto
    {

        public string NameAr { get; set; }

        public string NameEn { get; set; }
        
        public StaticPagedList<OutbuildingsType> OutbuildingsList { get; set; }

    }
}
