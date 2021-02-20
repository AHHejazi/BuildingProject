using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace pp.Domain.Entities.Lookup
{
   public class Supplies
    {

        public Supplies()
        {
            this.Buildings = new HashSet<Building>();
        }
        public virtual ICollection<Building> Buildings { get; set; }
        public int Id { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }
    }
}
