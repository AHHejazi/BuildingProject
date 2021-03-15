using Domain.App.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Services.Buildings
{
   public class BuildingVM
    {
        public string Number { get; set; }
        public IReadOnlyList<Building> BuildingList { get; set; }

    }
}
