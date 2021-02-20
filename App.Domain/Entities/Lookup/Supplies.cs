using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pp.Domain.Entities.Lookup
{
    public class Supplies
    {
        public int Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public ICollection<BuildingSupplies> BuildingSupplies { get; set; }
    }
}