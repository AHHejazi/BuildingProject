using Domain.App.Common;
using System;

namespace Application.App.Services.BuildingOuts
{
   public class BuildingOutDto :  AuditableEntity 
    {
        public Guid Id { get; set; }
        //public string NameAr { get; set; }
        //public string NameEn { get; set; }
        public Guid BuildingId { get; set; }
        public Guid ComponentId { get; set; }
        public Guid OutbuildingsTypeId { get; set; }
    }
}
