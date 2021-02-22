using Domain.App.Common;
using Domain.App.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.App.Entities
{
    public class Outbuildings : AuditableEntity
    {
        public Guid Id { get; set; }

        public Building Building { get; set; }

        public Guid BuildingId { get; set; }

        public decimal TotalSurfaceArea { get; set; }

        public OutbuildingsType OutbuildingsType { get; set; }


        public int OutbuildingsTypeId { get; set; }
    }
}
