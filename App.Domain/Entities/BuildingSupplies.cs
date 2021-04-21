using Domain.App.Common;
using Domain.App.Entities.Lookup;
using System;

namespace Domain.App.Entities
{
    public class BuildingSupplies : AuditableEntity
    {

        public Building Building { get; set; }

        public Supplement Supplies { get; set; }


        public Guid BuildingId { get; set; }


        public Guid SuppliesId { get; set; }


        public decimal Payment { get; set; }

       

    }
}
