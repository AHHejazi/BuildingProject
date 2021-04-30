using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.App.Entities.Lookup
{
    public class Component
    {
        public Guid Id { get; set; }

        public string NameAr { get; set; }

        public bool IsOutBuildingType { get; set; }

        public string NameEn { get; set; }

    }
}