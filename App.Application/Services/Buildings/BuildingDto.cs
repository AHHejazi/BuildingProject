﻿using Domain.App.Common;
using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Services.Buildings
{
   public class BuildingDto: AuditableEntity
    {
        public System.Guid Id { get; set; }
        public string Number { get; set; }
        public decimal EstimatedCost { get; set; }

        public Guid ProjectId { get; set; }

        public decimal TotalSurfaceArea { get; set; }

        public Nullable<int> NumberOfFloor { get; set; }

        public string LicenseNumber { get; set; }
        public string StampingNumber { get; set; }

        public int NumberOfApartment { get; set; }
        

        //public static implicit operator BuildingDto(Building v)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
