﻿using App.Domain.Common;
using pp.Domain.Entities.Lookup;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
   public class Building : AuditableEntity
    {

        public Building()
        {
            this.Supplies = new HashSet<Supplies>();
        }

        public Guid Id { get; set; }

        public virtual ICollection<Supplies> Supplies { get; set; }
        public string Number { get; set; }
        public decimal EstimatedCost { get; set; }

        public decimal TotalSurfaceArea { get; set; }

        public Nullable<byte> NumberOfFloor { get; set; }

        public string LicenseNumber { get; set; }
        public string StampingNumber { get; set; }

        public string NumberOfApartment { get; set; }

        public IEnumerable<Apartment> Apartments { get; set; }


        public IEnumerable<Outbuildings> Outbuildings { get; set; }

        //to check if I need to add this
        public IEnumerable<BuildingSupplies> BuildingSupplies { get; set; }

        //to check if we need to add

        public Project Project { get; set; }

        public Guid ProjectId { get; set; }

    }
}
