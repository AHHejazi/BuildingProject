using Domain.App.Common;
using Domain.App.Entities.Lookup;
using System;
using System.Collections.Generic;

namespace Domain.App.Entities
{
    public class Building : AuditableEntity
    {


        public Guid Id { get; set; }

        public virtual ICollection<Supplement> Supplies { get; set; }
        public virtual ICollection<Component> Components { get; set; }
        public string Number { get; set; }
        public decimal EstimatedCost { get; set; }

        public decimal TotalSurfaceArea { get; set; }

        public Nullable<int> NumberOfFloor { get; set; }

        public string LicenseNumber { get; set; }
        public string StampingNumber { get; set; }

        public int NumberOfApartment { get; set; }

        public ICollection<Apartment> Apartments { get; set; }


        public ICollection<Outbuilding> Outbuildings { get; set; }

        //to check if I need to add this
        public ICollection<BuildingSupplies> BuildingSupplies { get; set; }

        public ICollection<BuildingComponent> BuildingComponents { get; set; }


        //to check if we need to add

        public Project Project { get; set; }

        public Guid ProjectId { get; set; }

    }
}
