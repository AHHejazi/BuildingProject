using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.App.Entities.Lookup
{
   public class OutbuildingsType
    {
        public int Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public ICollection<Outbuilding> Outbuildings { get; set; }
    }
}
