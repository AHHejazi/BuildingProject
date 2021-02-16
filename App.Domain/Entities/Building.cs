using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
   public class Building : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Number { get; set; }
        public decimal EstimatedCost { get; set; }

        public decimal TotalSurfaceArea { get; set; }

        public Nullable<byte> NumberOfFloor { get; set; }

        public string LicenseNumber { get; set; }
        public string StampingNumber { get; set; }

        public string NumberOfApartment { get; set; }

        public IEnumerable<Apartment> Apartments { get; set; }


        public IEnumerable<Outbuildings> Outbuildings { get; set; }

    }
}
