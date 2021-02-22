using Domain.App.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.App.Entities
{
   public class Apartment : AuditableEntity
    {
        public Guid Id { get; set; }

        public Building Building { get; set; }

        public Guid BuildingId { get; set; }

        public decimal TotalSurfaceArea { get; set; }

        public string Number { get; set; }
    }
}
