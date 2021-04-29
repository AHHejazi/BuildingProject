using Domain.App.Common;
using System;

namespace Application.App.Services.Components
{
   public class ComponentDto :  AuditableEntity 
    {
        public System.Guid Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }
        public Guid? ComponentId { get; set; }
        public Guid? OutbuildingId { get; set; }

    }
}
