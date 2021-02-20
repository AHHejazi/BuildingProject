using App.Domain.Common;
using pp.Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
   public class BuildingSupplies : AuditableEntity
    {

        public Building Building { get; set; }

        public Supplies Supplies { get; set; }


        public Guid BuildingId { get; set; }


        public int SuppliesId { get; set; }


        public decimal Payment { get; set; }

       

    }
}
