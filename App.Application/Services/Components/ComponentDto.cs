using Domain.App.Common;
using System;

namespace Application.App.Services.Components
{
   public class ComponentDto :  AuditableEntity 
    {
        public System.Guid Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public bool IsOutBuildingType { get; set; }
    }
}
