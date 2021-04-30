using Domain.App.Common;
using Domain.App.Entities.Lookup;
using System;

namespace Domain.App.Entities
{
    public class BuildingOut : AuditableEntity
    {
        public Guid Id { get; set; }

        public Building Building { get; set; }

        public Component Component { get; set; }


        public OutbuildingsType OutbuildingsType { get; set; }

        public Guid BuildingId { get; set; }


        public Guid ComponentId { get; set; }

        public Guid OutbuildingsTypeId { get; set; }

    }
}
