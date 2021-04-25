using Domain.App.Common;
using Domain.App.Entities.Lookup;
using System;

namespace Domain.App.Entities
{
    public class BuildingComponent : AuditableEntity
    {

        public Building Building { get; set; }

        public Component Component { get; set; }


        public Guid BuildingId { get; set; }


        public Guid ComponentId { get; set; }

       

    }
}
