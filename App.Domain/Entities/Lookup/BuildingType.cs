using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.App.Entities.Lookup
{
    public class BuildingType
    {
            public int Id { get; set; }

            public string Number { get; set; }


            public ICollection<Building> Buildings { get; set; }
    }
}
