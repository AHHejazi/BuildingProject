using Domain.App.Entities;
using Framework.Core.ListManagment;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Services.Buildings
{
   public class BuildingVM : PagingDto
    {
        public decimal? EstimatedCost { get; set; }
        public int? NumberOfFloor { get; set; }
        public Guid? ProjectId { get; set; }

        public StaticPagedList<Building> BuildingList { get; set; }

    }
}
